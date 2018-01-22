using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	Camera Camara;
	public GameObject Player;
	Vector3 InitPosition;
	Vector3 PlayerPosition;
	Vector3 Offset;
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
		
	}
}
