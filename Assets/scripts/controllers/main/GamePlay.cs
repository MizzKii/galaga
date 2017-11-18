using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {

	[SerializeField]
	GameObject ship;
	[SerializeField]
	GameObject enemyWave;

	StateModal stateModal;
	ScoreModal scoreModal;

	// Use this for initialization
	void Start () {
		stateModal = StateModal.getInstance ();
		scoreModal = ScoreModal.getInstance ();
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
		if (Input.GetKeyDown (KeyCode.A)) {
			stateModal.setState (GameState.over);
		}
	}

	void HandleGameStart () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			stateModal.setState (GameState.ready);
			Invoke ("GameStart", 3f);
		}
	}

	void HandleGameOver () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			stateModal.setState (GameState.ready);
			scoreModal.setPoint (0);
			Invoke ("GameStart", 3f);
		}
	}

	void GameStart () {
		stateModal.setState (GameState.play);
		GameObject.Instantiate (ship);
		GameObject.Instantiate (enemyWave);
	}
}
