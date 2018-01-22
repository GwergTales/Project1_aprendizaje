using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public GameObject Boss;
	EnemyHealth BossHealth;
	Rigidbody WallRb;
	BoxCollider Collider;
	// Use this for initialization
	void Start () {
		BossHealth = Boss.GetComponent<EnemyHealth> ();
		WallRb = GetComponent<Rigidbody> ();
		Collider = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (BossHealth.Health <= 0) {
			Collider.enabled = false;
			WallRb.isKinematic = false;
			WallRb.AddForce (new Vector3 (0f, -0.1f, 0f), ForceMode.Impulse);
		}
			//transform.Translate (new Vector3 (0f, -0.01f, 0f) * Time.deltaTime);
	}
}
