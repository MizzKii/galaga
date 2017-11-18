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

	// Use this for initialization
	void Start () {
		translateLimitX = new CameraUtil ().getCameraWidth () - halfWidth;
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput ();
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
		transform.Translate (getForce (direction), Space.World);
	}

	// Shoot bullet
	void Shoot () {
		GameObject.Instantiate (bullet, transform.position, bullet.transform.rotation);
	}

	Vector3 getForce (Vector3 direction) {
		float force = Time.deltaTime * speed;
		float posX = transform.position.x + (direction.x * force);
		if (posX < -translateLimitX || posX > translateLimitX) {
			return Vector3.zero;
		}
		return direction * force;
	}
}
