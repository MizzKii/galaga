using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateModal {

	static StateModal stateModal = null;

	public static StateModal getInstance () {
		if (stateModal == null) {
			stateModal = new StateModal ();
		}
		return stateModal;
	}

	GameState gameState;

	private StateModal () {
		gameState = GameState.start;
	}

	public GameState getState () {
		return gameState;
	}

	public void setState (GameState gameState) {
		this.gameState = gameState;
	}
}
