using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Modal {

	static Player1Modal player1Modal;

	public static Player1Modal GetInstance () {
		if (player1Modal == null) {
			player1Modal = new Player1Modal ();
		}
		return player1Modal;
	}

	int life;

	private Player1Modal () {
		life = 1;
	}

	public int GetLife () {
		return life;
	}

	public void SetLife (int life) {
		this.life = life;
	}
}
