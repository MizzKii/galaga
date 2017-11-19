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
	int hightScore = 0;

	private ScoreModal () {
		hightScore = PlayerPrefs.GetInt ("HightScore", 0);
	}

	public int GetPoint () {
		return point;
	}

	public void SetPoint (int point) {
		this.point = point;
	}

	public int GetHightScore () {
		return hightScore;
	}

	public void SetHightScore (int hightScore) {
		PlayerPrefs.SetInt ("HightScore", hightScore);
		this.hightScore = hightScore;
	}
}
