using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour {

	EnemyHealth health;
	NavMeshAgent Nav;
	GameObject Player;
	GameObject prefab;
	PlayerHealth PlayerH;
	AudioSource Shooting;


	float timer;
	float speed;
	float angularSpeed;
	//float timer2;

	public float power;
	// Use this for initialization
	void Start () {
		Nav = GetComponent<NavMeshAgent> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
		PlayerH = Player.GetComponent<PlayerHealth> ();

		speed = Nav.speed;
		angularSpeed = Nav.angularSpeed;
		prefab = Resources.Load ("EnemyProyectil") as GameObject;
		health = GetComponent<EnemyHealth> ();
		Shooting = GetComponent<AudioSource> ();
		timer = 0f;


	}
	
	// Update is called once per frame
	void Update () {
		
		timer = timer + Time.deltaTime;
		StartCoroutine ("Follow");
		StartCoroutine("Shoot");


	}	

	IEnumerator Shoot(){
		if ((transform.position - Player.transform.position).magnitude < 20 && timer>1f && health.Health>0 && PlayerH.Health>0) {
			GameObject projectile = Instantiate(prefab) as GameObject;
			projectile.transform.position = transform.position+(Player.transform.position-transform.position).normalized;
			projectile.transform.rotation = transform.rotation;
			Rigidbody rb = projectile.GetComponent<Rigidbody> ();
			rb.velocity= (Player.transform.position-transform.position)* power ;
			Shooting.Play ();
			Destroy (projectile, 2);
			timer = 0f;

		}
		yield return new WaitForSeconds (.1f); 
	
	
	}
	IEnumerator Follow(){

		Nav.SetDestination (Player.transform.position);
		if ((transform.position - Player.transform.position).magnitude > 10 && (transform.position - Player.transform.position).magnitude < 30 && health.Health > 0 && PlayerH.Health > 0) {

			Nav.speed = speed;

		} else if (health.Hitted == true && health.Health > 0 && PlayerH.Health > 0 && (transform.position - Player.transform.position).magnitude > 10) {
			Nav.speed = speed;
		
		}else {
			Nav.speed = 0;
			if(health.Health >0)
				transform.LookAt(Player.transform);
		}



		yield return new WaitForSeconds (.1f);
	
	}

}
