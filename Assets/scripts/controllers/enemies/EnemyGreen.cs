using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : BaseEnemy {

	[SerializeField]
	GameObject beam;

	Animator animator;
	bool isStop = false;
	bool isBeam = false;

	// Use this for initialization
	void Start () {
		base.Start ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isStop) {
			base.Update ();
		}
	}

	public override void Attack () {
		if (!this.isAttacking) {
			isBeam = false;
			isStop = false;
		}
		base.Attack ();
	}

	protected override void OnAttacking () {
		base.OnAttacking ();
		if (!isBeam && transform.position.y < -2) {
			isStop = true;
			GameObject.Instantiate (beam, transform);
			Invoke ("HaveBeam", 3f);
		}
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

	void HaveBeam () {
		this.isBeam = true;
		isStop = false;
	}
}
