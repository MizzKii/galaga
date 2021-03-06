﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePlay : MonoBehaviour {

	[SerializeField]
	string high = "HIGH";
	[SerializeField]
	string score = "SCORE";
	[SerializeField]
	string player1 = "1UP";
	[SerializeField]
	float lineHeight = 20;
	[SerializeField]
	Texture2D ship;
	[SerializeField]
	GUISkin skinDefault;
	[SerializeField]
	GUIStyle fontLeftStyle;
	[SerializeField]
	GUIStyle fontRightStyle;
	[SerializeField]
	GUIStyle scoreStyle;

	StateModal stateModal;
	ScoreModal scoreModal;
	Player1Modal player1Modal;

	Vector2 shipSize;
	Rect highRec;
	Rect scoreRec;
	Rect highScoreRec;
	Rect player1Rec;
	Rect player1ScoreRec;
	List<Rect> player1LifeRec;

	// Use this for initialization
	void Start () {
		stateModal = StateModal.GetInstance ();
		scoreModal = ScoreModal.GetInstance ();
		player1Modal = Player1Modal.GetInstance ();

		shipSize = new Vector2 (30, 30);
		Vector2 size = new Vector2 (120, lineHeight);
		float posX = Screen.width - (size.x + 20);
		float posY = lineHeight * 2;
		highRec = new Rect (new Vector2 (posX, posY), size);
		posY += lineHeight;
		scoreRec = new Rect (new Vector2 (posX, posY), size);
		posY += lineHeight;
		highScoreRec = new Rect (new Vector2 (posX, posY), size);
		posY += lineHeight * 2;
		player1Rec = new Rect (new Vector2 (posX, posY), size);
		posY += lineHeight;
		player1ScoreRec = new Rect (new Vector2 (posX, posY), size);
		posY += lineHeight * 2;
		player1ScoreRec = new Rect (new Vector2 (posX, posY), size);
		posY += lineHeight * 2;
		player1LifeRec = new List<Rect> ();
		AddShipRects (2, new Vector2 (posX, posY));
	}

	void OnGUI () {
		if (stateModal.getState () == GameState.play) {
			int p1RecCount = player1LifeRec.Count;
			int life = player1Modal.GetLife () - 1;
			if (life > p1RecCount) {
				AddShipRects (life - p1RecCount);
			}
			GUI.skin = skinDefault;
			GUI.Label (highRec, high, fontLeftStyle);
			GUI.Label (scoreRec, score, fontRightStyle);
			GUI.Label (highScoreRec, scoreModal.GetHightScore ().ToString (), scoreStyle);
			GUI.Label (player1Rec, player1, fontLeftStyle);
			GUI.Label (player1ScoreRec, scoreModal.GetPoint ().ToString (), scoreStyle);
			for (int i = 0; i < life; i++) {
				GUI.DrawTexture (player1LifeRec[i], ship);
			}
		}
	}

	void AddShipRects (int count) {
		Vector2 lastPos = player1LifeRec [player1LifeRec.Count - 1].position;
		lastPos.x += shipSize.x;
		AddShipRects (count, lastPos);
	}

	void AddShipRects (int count, Vector2 pos) {
		for (int i = 0; i < count; i++) {
			player1LifeRec.Add (new Rect (pos, shipSize));
			pos.x += shipSize.x;
		}
	}
}
