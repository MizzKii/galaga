using System.Collections;
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

	Vector2 shipSize;
	Rect highRec;
	Rect scoreRec;
	Rect highScoreRec;
	Rect player1Rec;
	Rect player1ScoreRec;
	List<Rect> player1LifeRec;

	int lift = 2;

	// Use this for initialization
	void Start () {
		stateModal = StateModal.getInstance ();
		scoreModal = ScoreModal.getInstance ();

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
		AddShipRects (lift, new Vector2 (posX, posY));
	}

	void OnGUI () {
		if (stateModal.getState () == GameState.play) {
			int p1RecCount = player1LifeRec.Count;
			if (lift > p1RecCount) {
				AddShipRects (lift - p1RecCount);
			}
			GUI.skin = skinDefault;
			GUI.Label (highRec, high, fontLeftStyle);
			GUI.Label (scoreRec, score, fontRightStyle);
			GUI.Label (highScoreRec, "0", scoreStyle);
			GUI.Label (player1Rec, player1, fontLeftStyle);
			GUI.Label (player1ScoreRec, scoreModal.getPoint ().ToString (), scoreStyle);
			for (int i = 0; i < player1LifeRec.Count; i++) {
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
