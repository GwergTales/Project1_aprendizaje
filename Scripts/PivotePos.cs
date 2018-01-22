using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotePos : MonoBehaviour {

	Camera Camara;

	public GameObject Player;
	public GameObject PivoteFijo;
	Vector3 InitPosition;
	Vector3 PlayerPosition;
	Vector3 Offset;
	float mouseX;
	float mouseY;
	// Use this for initialization
	void Start () {

		PlayerPosition = Player.transform.position;

		Camara = GetComponent<Camera>();
		InitPosition = transform.position;
		Offset = transform.position - PlayerPosition;
	}

	// Update is called once per frame
	void Update () {

		PlayerPosition = Player.transform.position;
		transform.position = PlayerPosition + Offset;
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");
		transform.Rotate(new Vector3(0f,mouseX,0f),Space.World);
		transform.Rotate(new Vector3(mouseY,0f,0f));
		PivoteFijo.transform.Rotate(new Vector3(0f,mouseX,0f));
	}
}
