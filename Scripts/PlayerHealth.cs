using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float Health;
	public float MaxHealth;
	public AudioSource DamageSound;
	public bool Dead;
	public Slider HealthSlider;
	public Text HealthText;
	public Image DamageImage;
	public GameObject Player;

	CharControl Controller;
	CharacterController CharController;
	SphereCollider Collider;
	Rigidbody PlayerRb;
	bool Hitted;

	// Use this for initialization
	void Start () {
		
		Health = MaxHealth;	
		Player=GameObject.FindGameObjectWithTag("Player");
		PlayerRb = GetComponent<Rigidbody> ();
		Controller = GetComponent<CharControl> ();
		CharController = GetComponent<CharacterController> ();
		Collider = GetComponent<SphereCollider> ();
		Dead = false;


	}
	
	// Update is called once per frame
	void Update () {

		HealthUpdate ();

		Die ();

	}
	void OnTriggerEnter(Collider Other){
		if (Other.tag == "EnemyProyectil") {
			Damaged (10f);
		}
	
	}
	void HealthUpdate(){
		if (Health < MaxHealth && Health>0f) {
			Health = (Health + 0.5f * Time.deltaTime); 

		}
		HealthSlider.value = Health;
		HealthText.text = Mathf.RoundToInt(Health) + "/"+MaxHealth;
	}
	void Die(){
		if (Health <= 0f) {
			Dead = true;
			Controller.enabled = false;
			CharController.enabled = false;
			Collider.isTrigger = false;
			PlayerRb.isKinematic = false;
			//Destroy (Player, 5);

		}
	}
	void Damaged (float Damage){
		Health = Health - Damage;
		DamageSound.Play ();
		Hitted = true;
	}
	IEnumerator HitImage(){
		
		for (int i = 0; i < 255; i++) {
			
			yield return new WaitForSeconds (0.1f);
		
		}
	
	}
}
