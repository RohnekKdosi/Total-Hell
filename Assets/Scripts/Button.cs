using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	
	public float addAmmount;
	public GameObject counter;
	Counter counterScript;
	// Use this for initialization
	void Start () {
		counterScript = counter.GetComponent<Counter>();
	}
	
	void OnMouseDown () {
		counterScript.parameter += addAmmount;
	}
}
