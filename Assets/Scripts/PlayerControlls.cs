using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlls : MonoBehaviour {
	
	public float speed;
	private Rigidbody2D rb2d;
	private GameObject controller;
	private GameController controlScript;
	private Text shieldText;
	int shields;
	bool moveUp;
	bool moveDown;
	bool moveLeft;
	bool moveRight;
	bool invincible;
	float movehorizontal;
	float movevertical;
	float timeTillOutOfShield;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		controller = GameObject.FindWithTag("GameController");
		shieldText = GameObject.FindWithTag("ShieldText").GetComponent<Text>();
		controlScript = controller.GetComponent<GameController>();
	}
	
	void FixedUpdate () {
			moveUp = Input.GetKey("w");
			moveDown = Input.GetKey("s");
			moveLeft = Input.GetKey("a");
			moveRight = Input.GetKey("d");
		if (moveUp == false && moveDown == false || moveUp == true && moveDown == true)
		{
			movevertical = 0;
		}
		else
		{
			if (moveUp == true)
			{
				movevertical = 1;
			}
			else
			{
				if (moveDown == true)
				{
					movevertical = -1;
				}
			}
		}
		if ((moveLeft == false && moveRight == false) || (moveLeft == true && moveRight == true))
		{
			movehorizontal = 0;
		}
		else
		{
			if (moveRight == true)
			{
				movehorizontal = 1;
			}
			else
			{
				if (moveLeft == true)
				{
					movehorizontal = -1;
				}
			}
		}
		Vector2 movement = new Vector2(movehorizontal, movevertical);
		rb2d.velocity = movement * speed;
	}
	
	void OnCollisionEnter2D (Collision2D other) {
		if ((other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("TNT")) && !invincible) {
			controlScript.GameOver();
			Destroy (other.gameObject);
			gameObject.SetActive(false);
		}
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Shield")) {
			shields++;
			Destroy (other.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		shieldText.text = "Shields: " + shields;
		if (Input.GetKeyDown("space") && shields > 0) {
			timeTillOutOfShield = Time.timeSinceLevelLoad + 3f;
			invincible = true;
			shields--;
		}
		if (Time.timeSinceLevelLoad > timeTillOutOfShield) {
			invincible = false;
		}
	}
}
