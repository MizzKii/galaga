using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	[SerializeField]
	int speed = 5;
	[SerializeField]
	GameObject bullet;

	float translateLimitX;
	float halfWidth = 0.5f;

	GamePlay gamePlay;
	bool isDmg = false;
	bool isDestory = false;

	// Use this for initialization
	void Start () {
		translateLimitX = new CameraUtil ().getCameraWidth () - halfWidth;

		Invoke ("ShipReady", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDestory) {
			HandleInput ();
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy" && isDmg) {
			isDestory = true;
			Animator animator = GetComponent<Animator> ();
			if (animator == null) {
				print ("test");
				ShipDestory ();
				return;
			} else {
				animator.SetTrigger ("Destory");
				Invoke ("ShipDestory", 0.29f);
			}
		}
	}

	void ShipDestory () {
		if (gamePlay != null) {
			gamePlay.ShipDestory ();
		}
		Destroy (gameObject);
	}

	void ShipReady () {
		isDmg = true;
	}

	// Handle input
	void HandleInput () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Move (Vector3.left);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			Move (Vector3.right);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot ();
		}
	}

	// Ship control
	void Move (Vector3 direction) {
		transform.Translate (GetForce (direction), Space.World);
	}

	// Shoot bullet
	void Shoot () {
		GameObject.Instantiate (bullet, transform.position, bullet.transform.rotation);
	}

	Vector3 GetForce (Vector3 direction) {
		float force = Time.deltaTime * speed;
		float posX = transform.position.x + (direction.x * force);
		if (posX < -translateLimitX || posX > translateLimitX) {
			return Vector3.zero;
		}
		return direction * force;
	}

	public void SetGamePlay (GamePlay gamePlay) {
		this.gamePlay = gamePlay;
	}
}
