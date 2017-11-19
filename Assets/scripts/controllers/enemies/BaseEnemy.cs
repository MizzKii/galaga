using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

	[SerializeField]
	protected int point = 100;
	protected float speed = 1;
	protected bool isAttacking = false;
	protected Vector3 direction;
	protected EnemyWave enemyWave;
	protected Vector3 position;

	// Use this for initialization
	protected virtual void Start () {
		enemyWave = GetComponentInParent<EnemyWave> ();
		position = transform.position - enemyWave.GetPosition ();
		speed = enemyWave.GetSpeed ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (isAttacking) {
			OnAttacking ();
		} else if (enemyWave != null) {
			transform.position = Vector3.Lerp(transform.position, enemyWave.GetPosition () + position, Time.deltaTime);
		}
	}

	void OnBecameInvisible () {
		isAttacking = false;
		Vector3 pos = transform.position;
		pos.y = 9;
		transform.position = pos;
	}

	protected virtual void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			int point = ScoreModal.GetInstance ().getPoint ();
			ScoreModal.GetInstance ().setPoint (this.point + point);
			CallEnemyWave ();
			Destroy (coll.gameObject);
			Destroy (gameObject);
		}
	}
	
	protected virtual void OnAttacking () {
		transform.Translate (direction * Time.deltaTime * speed, Space.Self);
	}

	public virtual void Attack () {
		if (isAttacking) {
			return;
		}
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {
			return;
		}
		direction = player.transform.position - transform.position;
		direction.Normalize ();
		isAttacking = true;
	}

	void CallEnemyWave () {
		EnemyWave wave = GetComponentInParent<EnemyWave> ();
		if (wave != null) {
			wave.DestoryEnemy (this);
		}
	}
}
