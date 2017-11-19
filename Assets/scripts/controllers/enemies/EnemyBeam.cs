using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestoryBeam", 2.9f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DestoryBeam () {
		Destroy (gameObject);
	}
}
