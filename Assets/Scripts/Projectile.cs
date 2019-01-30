using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	
	public float minMultiplier;
	public float addRange;
	private Rigidbody2D rb2d;
	Vector3 startPos;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		rb2d = GetComponent<Rigidbody2D>();
		Vector2 movement = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
		rb2d.AddForce(movement * Random.Range(minMultiplier, minMultiplier + Mathf.Abs(addRange)));
	}
	void OnTriggerExit2D (Collider2D other) {
		rb2d.velocity = new Vector2(0, 0);
		transform.position = startPos;
		Start();
	}
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag("TNT")) {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
