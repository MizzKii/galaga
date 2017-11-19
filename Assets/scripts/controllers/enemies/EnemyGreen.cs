using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : BaseEnemy {

	Animator animator;

	// Use this for initialization
	void Start () {
		base.Start ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	protected override void OnCollisionEnter2D(Collision2D coll) {
		if (!animator.GetBool ("haveHit") && coll.gameObject.tag == "Bullet") {
			Animator animator = GetComponent<Animator> ();
			animator.SetBool ("haveHit", true);
			Destroy (coll.gameObject);
		} else {
			base.OnCollisionEnter2D (coll);
		}
	}
}
