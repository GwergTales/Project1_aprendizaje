using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

	public Button historia;
	public Button salir;
	// Use this for initialization
	void Start () {
		historia.onClick.AddListener (Load);
		salir.onClick.AddListener (Salir);
	}
	
	// Update is called once per frame
	void Update () {
		//historia.onClick.AddListener (Load);

	}
	void Load(){
		SceneManager.LoadScene ("Escena1");
	}
	void Salir(){
		Application.Quit ();
	
	}
}
