using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModal {

	static ScoreModal scoreModal = null;

	static public ScoreModal GetInstance () {
		if (scoreModal == null) {
			scoreModal = new ScoreModal ();
		}
		return scoreModal;
	}

	int point = 0;

	private ScoreModal () {}

	public int getPoint () {
		return point;
	}

	public void setPoint (int point) {
		this.point = point;
	}
}
