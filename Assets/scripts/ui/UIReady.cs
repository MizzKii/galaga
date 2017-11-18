using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReady : MonoBehaviour {

	[SerializeField]
	string ready = "Ready";
	[SerializeField]
	GUISkin skinDefault;

	StateModal stateModal;

	Rect readyRec;

	// Use this for initialization
	void Start () {
		stateModal = StateModal.getInstance ();

		Vector2 size = new Vector2 (400, 100);
		float centerX = (Screen.width / 2) - (size.x / 2);
		float centerY = Screen.height / 2;
		Vector2 position = new Vector2 (centerX, centerY);
		readyRec= new Rect (position, size);
	}

	void OnGUI () {
		if (stateModal.getState () == GameState.ready) {
			GUI.skin = skinDefault;
			GUI.Label (readyRec, ready);
		}
	}
}
