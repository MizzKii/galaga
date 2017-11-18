using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : BaseEnemy {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			Destroy (coll.gameObject);
			if (!animator.GetBool ("haveHit")) {
				Animator animator = GetComponent<Animator> ();
				animator.SetBool ("haveHit", true);
			} else {
				int point = ScoreModal.getInstance ().getPoint ();
				ScoreModal.getInstance ().setPoint (this.point + point);
				Destroy (gameObject);
			}
		}
	}
}
