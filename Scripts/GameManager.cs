using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	GameObject Player;
	GameObject Pivote;
	public Button Reset;

	//AudioSource EpicMusic;
	public GameObject Boss;
	EnemyHealth BossHealth;
	public GameObject EpicMusic;
	public AudioSource EpicMusicSound;
	PlayerHealth PlayerH;
	PivotePos pivotePos;
	CharControl PlayerController;
	public GameObject GameOverText;
	public GameObject InitText;
	bool BossDead;
	// Use this for initialization
	void Start () {

		Cursor.visible = false;
		Cursor.lockState=CursorLockMode.Locked;
		Player = GameObject.FindGameObjectWithTag ("Player");
		BossHealth = Boss.GetComponent<EnemyHealth> ();
		//Boss = GameObject.FindGameObjectWithTag ("Boss");
		PlayerController = Player.GetComponent<CharControl> ();
		PlayerH = Player.GetComponent<PlayerHealth> ();
		Pivote = GameObject.Find ("Pivote");
		pivotePos = Pivote.GetComponent<PivotePos> ();
		EpicMusicSound = EpicMusic.GetComponent<AudioSource> ();
		InitText.SetActive (true);
		Time.timeScale = 0;
		Reset.onClick.AddListener (Restart);
		//EpicMusic = GetComponent<AudioSource> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerH.Dead == true) {
			GameOverText.SetActive(true);
			Cursor.visible = true;
			Cursor.lockState=CursorLockMode.None;


		
		}
		Pause ();
		if (Mathf.Abs ((Player.transform.position-Boss.transform.position).magnitude) <= 30f) {
			EpicMusic.SetActive (true);
		}
		if (BossHealth.Health <= 0) {
			BossDead = true;
			
		}
		if (BossDead == true)
			EpicMusicSound.volume =EpicMusicSound.volume - 0.2f*Time.deltaTime;

	}
	void Pause (){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
		if (InitText.activeSelf == true && Time.timeScale == 0 && Input.GetMouseButtonDown (0)) {
			Time.timeScale = 1;
			InitText.SetActive (false);
		}	
		if (Time.timeScale == 0) {
			pivotePos.enabled = false;
			PlayerController.enabled = false;
		} else {
			pivotePos.enabled = true;
			PlayerController.enabled = true;
		}

	}
	void Restart(){
		SceneManager.LoadScene ("Escena1");
	}
}
