using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
	
	public bool gameOn;
	public GameObject timeCounter;
	public GameObject bulletCounter;
	public GameObject bounceCounter;
	public GameObject charCounter;
	public GameObject projCounter;
	public GameObject powerUpCounter;
	public GameObject[] charPics = new GameObject[7];
	public GameObject[] projPics = new GameObject[11];
	public Text time;
	public Text projectiles;
	public Text bounciness;
	public Text character;
	public Text projectile;
	public Text powerUp;
	public Text manual;
	public Counter timeScript;
	public Counter bulletScript;
	public Counter bounceScript;
	public Counter charScript;
	public Counter projScript;
	public Counter powerUpScript;
	
	void Start () {
		timeScript = timeCounter.GetComponent<Counter>();
		bulletScript = bulletCounter.GetComponent<Counter>();
		bounceScript = bounceCounter.GetComponent<Counter>();
		charScript = charCounter.GetComponent<Counter>();
		projScript = projCounter.GetComponent<Counter>();
		powerUpScript = powerUpCounter.GetComponent<Counter>();
	}
	
	void DisableObjects (GameObject[] array) {
		foreach (GameObject i in array) {
			i.SetActive(false);
		}
	}
	
	void ChooseActive (GameObject[] array, Counter counter, Text randomText) {
		if (randomText != null) {
			if (counter.parameter >= counter.maxParam) {
				randomText.text = "Random";
				DisableObjects (array);
			}
			else {
				randomText.text = "";
				DisableObjects (array);
				array[(int)counter.parameter].SetActive(true);
			}
		}
	}
	
	void Update () {
		if (time != null && projectiles != null && bounciness != null && powerUp != null) {
			if (timeScript.parameter < timeScript.maxParam) {
				time.text = "" + timeScript.parameter;
			}
			else {
				time.text = "Unlimited";
			}
			projectiles.text = "" + bulletScript.parameter;
			bounciness.text = "" + bounceScript.parameter;
			if (powerUpScript.parameter <= powerUpScript.minParam) {
			powerUp.text = "Never";
			}
			else {
				powerUp.text = "" + powerUpScript.parameter;
			}
		}
		ChooseActive(charPics, charScript, character);
		ChooseActive (projPics, projScript, projectile);
		
		if (manual != null) {
			if (Input.GetKeyDown("m")) {
				manual.gameObject.SetActive (!manual.gameObject.activeSelf);
			}
		}
	}
}

