using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

	[SerializeField]
	protected int point = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected virtual void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			int point = ScoreModal.getInstance ().getPoint ();
			ScoreModal.getInstance ().setPoint (this.point + point);
			Destroy (coll.gameObject);
			Destroy (gameObject);
		}
	}
}
