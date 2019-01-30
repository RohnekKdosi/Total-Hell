using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	
	public GameObject buttonUnpressed;
	public GameObject buttonPressed;
	public GameObject settingsController;
	public GameObject spawner;
	public GameObject controller;
	public GameObject[] bullets = new GameObject[11];
	public GameObject[] players = new GameObject[7];
	public PhysicsMaterial2D material;
	public Collider2D hitbox;
	public Settings settingsScript;
	GameController controlScript;
	
	void Start () {
		settingsScript = settingsController.GetComponent<Settings>();
		hitbox = GetComponent<Collider2D>();
		buttonUnpressed.gameObject.SetActive (true);
		buttonPressed.gameObject.SetActive (false);
	}
	
	void OnMouseOver() {
		if (hitbox.enabled) {
			buttonPressed.gameObject.SetActive (true);
			buttonUnpressed.gameObject.SetActive (false);
		}
	}
	
	void OnMouseExit() {
		Start ();
	}
	
	void OnMouseDown () {
		DontDestroyOnLoad(settingsScript.gameObject);
		hitbox.enabled = false;
		buttonPressed.SetActive(false);
		buttonUnpressed.SetActive(false);
		material.bounciness = settingsScript.bounceScript.parameter;
		SceneManager.LoadScene(1);
	}
	
	public void InstructSpawner () {
		SpawnBullets spawnScript = spawner.GetComponent<SpawnBullets>();
		spawnScript.bulletsToSpawn = (int)settingsScript.bulletScript.parameter;
		if (settingsScript.charScript.parameter == settingsScript.charScript.maxParam) {
			spawnScript.player = players[Random.Range(0, players.Length -1)];
		}
		else {
			spawnScript.player = players[(int)settingsScript.charScript.parameter];
		}
		if (settingsScript.projScript.parameter == settingsScript.projScript.maxParam) {
			spawnScript.bullet = bullets[Random.Range(0, bullets.Length -1)];
		}
		else {
			spawnScript.bullet = bullets[(int)settingsScript.projScript.parameter];
		}
		spawnScript.Spawn();
	}
	
	public void InstructController () {
		controlScript = controller.GetComponent<GameController>();
		if (settingsScript.timeScript.parameter == settingsScript.timeScript.maxParam) {
			controlScript.unlimited = true;
		}
		controlScript.time = (int)settingsScript.timeScript.parameter;
		controlScript.PUTime = settingsScript.powerUpScript.parameter;
	}
	
	void Update () {
		
	}
}
