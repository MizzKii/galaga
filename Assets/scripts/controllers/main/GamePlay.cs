using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {

	[SerializeField]
	GameObject ship;
	[SerializeField]
	GameObject enemyWave;
	[SerializeField]
	int player1Life = 3;
	[SerializeField]
	float enemiesSpeed = 2f;
	[SerializeField]
	float enemiesSpeedUp = 0.5f;

	StateModal stateModal;
	ScoreModal scoreModal;
	Player1Modal player1Modal;

	float startSpeed;
	GameObject wave;

	// Use this for initialization
	void Start () {
		stateModal = StateModal.GetInstance ();
		scoreModal = ScoreModal.GetInstance ();
		player1Modal = Player1Modal.GetInstance ();

		startSpeed = enemiesSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		switch (stateModal.getState ()) {
		case GameState.start:
			HandleGameStart ();
			break;
		case GameState.over:
			HandleGameOver ();
			break;
		}
	}

	void HandleGameStart () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			stateModal.setState (GameState.ready);
			player1Modal.SetLife (player1Life);
			Invoke ("GameStart", 3f);
		}
	}

	void HandleGameOver () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			stateModal.setState (GameState.ready);
			player1Modal.SetLife (player1Life);
			scoreModal.setPoint (0);
			enemiesSpeed = startSpeed;
			Invoke ("GameStart", 3f);
		}
	}

	void GameStart () {
		stateModal.setState (GameState.play);
		InstantiateShip ();
		InstantiateWave ();
	}

	void InstantiateShip () {
		ShipController shipCon = GameObject.Instantiate (ship).GetComponent<ShipController> ();
		if (shipCon != null) {
			shipCon.SetGamePlay (this);
		}
	}

	public void InstantiateWave () {
		wave = GameObject.Instantiate (enemyWave);
		EnemyWave script = wave.GetComponent<EnemyWave> ();
		if (script != null) {
			script.InitWave (this, enemiesSpeed);
			enemiesSpeed += enemiesSpeedUp;
		}
	}

	public void ShipDestory () {
		int life = player1Modal.GetLife () - 1;
		player1Modal.SetLife (life);
		if (life > 0) {
			InstantiateShip ();
		} else {
			Destroy (wave);
			stateModal.setState (GameState.over);
		}
	}
}
