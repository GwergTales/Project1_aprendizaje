using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	Rigidbody rb;
	CharacterController CharController;
	Vector3 Speed;
	bool Pushing;
	float hInput;
	float vInput;
	bool jumpInput;
	Vector3 mov;
	float mouseX;
	public float Force = 100f;
	public float jumpForce;
	public GameObject Pivote;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		CharController = GetComponent<CharacterController> ();
		Pushing = false;
	}
	
	// Update is called once per frame
	void Update () {

		hInput = Input.GetAxis ("Horizontal");
		vInput = Input.GetAxis ("Vertical");
		jumpInput = Input.GetButtonDown ("Jump");
		mov = new Vector3 (hInput, 0f, vInput);
		mouseX = Input.GetAxis ("Mouse X");

	}
	void FixedUpdate(){
		ApplyForce ();

		Speed = rb.velocity;
		if (Mathf.Abs (hInput) > 0 || Mathf.Abs (vInput) > 0) {
			
			Pushing = true;
		}
		else{

			Pushing=false;
		}
		Debug.Log (rb.velocity.magnitude);
		if (jumpInput == true ) {
			Jump ();
		}
		if (Pushing == false && rb.velocity.magnitude > 0f && rb.velocity.y==0f) {
			DecreaseSpeed (Speed);
		}

		/*if (rb.velocity.magnitude > 0 && Vector3.Angle(rb.velocity,mov) != 0f) {

			rb.AddForce (mov*Speed*Time.deltaTime+rb.mass*rb.velocity*Time.deltaTime);
		
		}
	*/
	}

	void ApplyForce()
	{
		Vector3 PivoteDir = Pivote.transform.position;
		rb.AddForce (mov*Force*Time.deltaTime);	

			
	}
	void Jump(){
		rb.AddForce(new Vector3(0f,jumpForce,0f),ForceMode.Impulse);
	}
	void DecreaseSpeed(Vector3 speed){
		Vector3 ContrarySpeed = new Vector3 ((-1f) * speed.x, (-1f) * speed.y, (-1f) * speed.z);
		if (speed.magnitude > 0f) {
			rb.AddForce (ContrarySpeed*10*rb.mass);
		}
	}
}
