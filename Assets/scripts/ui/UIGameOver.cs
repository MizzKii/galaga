using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour {

	[SerializeField]
	string gameOver = "GAME OVER";
	[SerializeField]
	string hightScore = "HIGHT SCORE";
	[SerializeField]
	string score = "SCORE";
	[SerializeField]
	string playAgain = "Press space to play again";
	[SerializeField]
	GUISkin skinDefault;
	[SerializeField]
	GUIStyle titleStyle;
	[SerializeField]
	GUIStyle fontWhiteStyle;

	StateModal stateModal;
	ScoreModal scoreModal;

	Rect gameOverRec;
	Rect hightScoreRec;
	Rect hightScorePointRec;
	Rect scoreRec;
	Rect scorePointRec;
	Rect playAgainRec;

	// Use this for initialization
	void Start () {
		stateModal = StateModal.GetInstance ();
		scoreModal = ScoreModal.GetInstance ();

		Vector2 size = new Vector2 (500, 50);
		float centerX = (Screen.width / 2) - (size.x / 2);
		float centerY = Screen.height / 2;
		gameOverRec = new Rect (new Vector2 (centerX, centerY - 150), size);
		hightScoreRec = new Rect (new Vector2 (centerX, centerY - 80), size);
		hightScorePointRec = new Rect (new Vector2 (centerX, centerY - 50), size);
		scoreRec = new Rect (new Vector2 (centerX, centerY - 10), size);
		scorePointRec = new Rect (new Vector2 (centerX, centerY + 20), size);
		playAgainRec = new Rect (new Vector2 (centerX, centerY + 100), size);
	}

	void OnGUI () {
		if (stateModal.getState () == GameState.over) {
			GUI.skin = skinDefault;
			GUI.Label (gameOverRec, gameOver, titleStyle);
			GUI.Label (hightScoreRec, hightScore);
			GUI.Label (hightScorePointRec, scoreModal.GetHightScore ().ToString (), fontWhiteStyle);
			GUI.Label (scoreRec, score);
			GUI.Label (scorePointRec, scoreModal.GetPoint ().ToString (), fontWhiteStyle);
			GUI.Label (playAgainRec, playAgain, fontWhiteStyle);
		}
	}
}
