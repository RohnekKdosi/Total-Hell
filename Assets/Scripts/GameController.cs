using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	public int time;
	public bool unlimited;
	public float PUTime;
	public GameObject GOScreen;
	public GameObject winScreen;
	public GameObject settings;
	public GameObject starter;
	public GameObject[] powerUps = new GameObject[2];
	public Text GOText;
	public PhysicsMaterial2D material;
	float timeToSpawn;
	bool isGameOver;
	StartGame startScript;
	
	void Start () {
		GOScreen.SetActive(false);
		winScreen.SetActive(false);
		GOText.text = "";
		starter = GameObject.FindWithTag("Starter");
		startScript = starter.GetComponent<StartGame>();
		startScript.controller = this.gameObject;
		startScript.InstructController();
		timeToSpawn = PUTime;
	}
	public void GameOver () {
		GOScreen.SetActive(true);
		isGameOver = true;
		//Can't use the method with one string because this uses C# 4.0
		GOText.text = "Time survived: " + Time.timeSinceLevelLoad +"\nProjectiles: " + startScript.settingsScript.bulletScript.parameter + "\nBounciness: " + material.bounciness;
	}
	
	public void Win () {
		GameObject[] bullets = GameObject.FindGameObjectsWithTag ("Bullet");
		foreach (GameObject i in bullets) {
			Destroy(i);
		}
		GameObject[] TNTs = GameObject.FindGameObjectsWithTag("TNT");
		foreach (GameObject i in TNTs) {
			Destroy(i);
		}
		isGameOver = true;
		winScreen.SetActive(true);
	}
	
	void Update () {
		bool restart = Input.GetKey("r");
		bool exit = Input.GetKey("escape");
		if (restart) {
			SceneManager.LoadScene(1);
		}
		if (exit) {
			settings = GameObject.FindWithTag("Settings");
			Destroy(settings);
			SceneManager.LoadScene(0);
		}
		if (Time.timeSinceLevelLoad >= time && !unlimited && !isGameOver) {
			Win();
		}
		if (PUTime != 4 && Time.timeSinceLevelLoad > timeToSpawn && !isGameOver) {
			Vector3 spawnPos = new Vector3 (Random.Range(6.45f, -6.45f), Random.Range(4.8f, -4.8f), 0);
			Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnPos, Quaternion.identity);
			timeToSpawn += PUTime;
		}
	}
}
