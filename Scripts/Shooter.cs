using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject prefab;

	public float power;
	float timer;
	AudioSource Shoot;
	TrailRenderer Trail;
	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("Proyectil") as GameObject;
		timer = 0f;
		Shoot = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;
		if(Input.GetMouseButton(0) && timer > 1f ){
			
			GameObject projectile = Instantiate(prefab) as GameObject;
			projectile.transform.position = transform.position+Camera.main.transform.forward;
			Trail = projectile.GetComponent<TrailRenderer> ();

			Rigidbody rb = projectile.GetComponent<Rigidbody> ();
			rb.velocity= Camera.main.transform.forward* power;

			timer = 0f;
			Destroy (projectile, 3);
			projectile.transform.rotation = transform.rotation;
			Shoot.Play ();
			Trail.enabled = true;

		}
		
	}


}
