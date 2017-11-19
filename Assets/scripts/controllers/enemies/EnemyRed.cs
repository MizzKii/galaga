using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : BaseEnemy {

	[SerializeField]
	GameObject bullet;

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	public override void Attack () {
		if (!this.isAttacking) {
			Invoke ("InstantiateBullet", 1f);
		}
		base.Attack ();
	}

	void InstantiateBullet () {
		if (this.isAttacking) {
			GameObject.Instantiate (bullet, transform);
			Invoke ("InstantiateBullet", 1f);
		}
	}
}
