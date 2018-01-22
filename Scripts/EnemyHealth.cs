using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour {

	BoxCollider Collider;
	NavMeshAgent Nav;
	Animator DeadAnim;

	public bool Hitted;
	public GameObject Este;
	public float Health;
	public AudioSource Hit;
	 //ParticleSystem HitParticles;
	//public GameObject HitParticlesObject;
	//public Animatsion DeadAnim;
	// Use this for initialization
	void Start () {
		
		DeadAnim = GetComponent<Animator> ();
		Nav = GetComponent <NavMeshAgent> ();
		Collider = GetComponent<BoxCollider> ();
		//HitParticles = HitParticlesObject.GetComponent<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
		Die();
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Proyectil"){
			Damaged (20f);
		}
	}
	void Die(){
		if (Health <= 0) {
			Nav.enabled = false;
			Collider.enabled = false;
			Destroy (Este, 5);
			transform.Translate (new Vector3 (0f, -0.01f, 0f)*Time.deltaTime);
			//DeadAnim.SetTrigger ("Dead");
		}
	}
	void Damaged(float amount){
		Health = Health - amount;
		Hitted = true;
	}

}
