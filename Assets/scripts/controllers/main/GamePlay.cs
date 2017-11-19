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
	bool canRestart = false;
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
		if (canRestart && Input.GetKeyDown (KeyCode.Space)) {
			stateModal.setState (GameState.ready);
			player1Modal.SetLife (player1Life);
			scoreModal.SetPoint (0);
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

	void SetRestart () {
		canRestart = true;
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
			canRestart = false;
			stateModal.setState (GameState.over);
			int score = scoreModal.GetPoint ();
			int hightScore = scoreModal.GetHightScore ();
			if (score > hightScore) {
				scoreModal.SetHightScore (score);
			}
			Invoke ("SetRestart", 1.5f);
		}
	}
}
