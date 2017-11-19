using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour {


	[SerializeField]
	float minAttractRange = 0.5f;
	[SerializeField]
	float maxAttractRange = 2f;

	float speed = 2;
	float halfWidth = 5;
	float translateLimitX;

	Vector3 position;
	Vector3 direction = Vector3.right;

	StateModal stateModal;
	GamePlay gamePlay;
	List<BaseEnemy> enemies;

	// Use this for initialization
	void Start () {
		stateModal = StateModal.GetInstance ();
		position = transform.position;

		translateLimitX = new CameraUtil ().getCameraWidth () - halfWidth;
		enemies = new List<BaseEnemy> ();
		GetComponentsInChildren<BaseEnemy> (enemies);

		Invoke("EnemyAttack", Random.Range (minAttractRange, maxAttractRange));
	}
	
	// Update is called once per frame
	void Update () {
		MoveWave ();
	}

	void MoveWave () {
		position += GetForce (direction);
	}
		
	Vector3 GetForce (Vector3 direction) {
		float force = Time.deltaTime * speed;
		float posX = position.x + (direction.x * force);
		if (posX < -translateLimitX || posX > translateLimitX) {
			this.direction *= -1;
			return Vector3.zero;
		}
		return direction * force;
	}

	void EnemyAttack () {
		BaseEnemy enemy = enemies[Random.Range(0, enemies.Count)];
		if (enemy != null) {
			enemy.Attack ();
		}
		if (stateModal.getState () == GameState.play) {
			Invoke ("EnemyAttack", Random.Range (minAttractRange, maxAttractRange));
		}
	}

	// When enemy have destory
	public void DestoryEnemy (BaseEnemy enemy) {
		enemies.Remove (enemy);
		if (enemies.Count == 0) {
			if (gamePlay != null) {
				gamePlay.InstantiateWave ();
			}
			Destroy (gameObject);
		}
	}

	public void InitWave (GamePlay gamePlay, float speed) {
		this.gamePlay = gamePlay;
		this.speed = speed;
	}

	public Vector3 GetPosition () {
		if (position == null) {
			position = transform.position;
		}
		return position;
	}

	public float GetSpeed () {
		return speed;
	}
}
