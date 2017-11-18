using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour {

	[SerializeField]
	int speed = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * Time.deltaTime * speed, Space.World);
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
