using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : MonoBehaviour {

	[SerializeField]
	string title = "Galaga";
	[SerializeField]
	string startMessage = "Press space to start";
	[SerializeField]
	GUISkin skinDefault;
	[SerializeField]
	GUIStyle titleStyle;

	StateModal stateModal;

	Rect titleRec;
	Rect startMessageRec;

	void Start () {
		stateModal = StateModal.GetInstance ();

		Vector2 size = new Vector2 (400, 50);
		float centerX = (Screen.width / 2) - (size.x / 2);
		float centerY = Screen.height / 2;
		Vector2 posTitle = new Vector2 (centerX, centerY - 80);
		Vector2 posStartMessage = new Vector2 (centerX, centerY + 50);

		titleRec = new Rect (posTitle + (Vector2.up * 10), size);
		startMessageRec = new Rect (posStartMessage, size);
	}

	void OnGUI () {
		if (stateModal.getState () == GameState.start) {
			GUI.skin = skinDefault;
			GUI.Label (titleRec, title, titleStyle);
			GUI.Label (startMessageRec, startMessage);
		}
	}
}
