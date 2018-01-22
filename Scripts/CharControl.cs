using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {


	CharacterController Controller;

	Vector3 mov;
	Vector3 rotx;
	Vector3 roty;
	AudioSource Bushes;
	GameObject Player;

	float hInput;
	float vInput;
	float mouseX;
	float mouseY;
	float Mousey;
	float timer;


	public float speed;
	public GameObject Camara;
	public GameObject PivoteFijo;

	// Use this for initialization
	void Start () {
		Controller = GetComponent<CharacterController> ();
		Bushes = GetComponent<AudioSource> ();
		Player = Controller.gameObject;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		SetInput ();
		mov = new Vector3 (hInput, 0f, vInput);
		rotx=new Vector3(0f,mouseX,0f);
		roty = new Vector3 (mouseY, 0f, 0f);
		ApplyGravity ();
		Move (mov);
		Rotate (rotx,roty);


	
	}
	void Move(Vector3 Mov){

		//Controller.Move (((Camara.transform.right*Mov.x)+(Camara.transform.forward*Mov.z))*speed*Time.deltaTime);
		Controller.Move (((PivoteFijo.transform.right*Mov.x)+(PivoteFijo.transform.forward*Mov.z))*speed*Time.deltaTime);
		Bushes.Play ();
		//Controller.Move (Mov * speed * Time.deltaTime);
	}
	void ApplyGravity(){
		Controller.Move (Physics.gravity * Time.deltaTime);
	}
	void SetInput(){
		hInput = Input.GetAxis ("Horizontal");
		vInput = Input.GetAxis ("Vertical");
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");
	


	}
	void Rotate(Vector3 Rotx, Vector3 Roty){
		transform.Rotate(Rotx,Space.World);
		transform.Rotate (Roty) ;
		
	}
	IEnumerator Jump(){
		
		while (timer < 0.3f) {
			Controller.Move (Player.transform.up );
			timer += Time.deltaTime;
			Debug.Log (timer);
			yield return null; 
		}
	
	}
}
