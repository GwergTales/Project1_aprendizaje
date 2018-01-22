using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour {

	GameObject Player;
	public GameObject EndText;
	public GameObject TheEndText;
	public GameObject EndImage;
	public GameObject Pivote;
	//CharControl PlayerController;
	//PivotePos PivoteController;
	public Button Exit;
	public GameObject ButtonObj;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		//PlayerController = Player.GetComponent<CharControl> ();
		//PivoteController = Pivote.GetComponent<PivotePos> ();
		Exit.onClick.AddListener (Load);

	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//PlayerController.enabled = false;
			//PivoteController.enabled = false;
			EndText.SetActive (true);
			ButtonObj.SetActive (true);
			TheEndText.SetActive (true);
			EndImage.SetActive(true);
			Cursor.visible = true;
			Cursor.lockState=CursorLockMode.None;
		
		}
	}
	void Load(){
		SceneManager.LoadScene ("MainMenu");
	}
}
