using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour {
	
	public int bulletsToSpawn;
	public Vector2 minCoords;
	public Vector2 maxCoords;
	public Vector2 forbiddenMinCoords;
	public Vector2 forbiddenMaxCoords;
	public GameObject bullet;
	public GameObject player;
	GameObject starter;
	StartGame startScript;
	void Start () {
		starter = GameObject.FindWithTag("Starter");
		startScript = starter.GetComponent<StartGame>();
		startScript.spawner = this.gameObject;
		startScript.InstructSpawner ();
	}
	
	public void Spawn () {
		if (bulletsToSpawn > 0 && bullet != null && player != null) {
			while (GameObject.FindGameObjectsWithTag("Bullet").Length < bulletsToSpawn) {
				Vector3 spawnPos = new Vector3 (Random.Range(minCoords.x, maxCoords.x), Random.Range(minCoords.y, maxCoords.y), 0);
				if (!(spawnPos.x < forbiddenMaxCoords.x && spawnPos.x > forbiddenMinCoords.x && spawnPos.y < forbiddenMaxCoords.y && spawnPos.y > forbiddenMinCoords.y)) {
					Instantiate(bullet, spawnPos, Quaternion.identity);
				}
			}
			Vector3 playerPos = new Vector3 (0, 0, 0);
			Instantiate(player, playerPos, Quaternion.identity);
		}
		
	}
	
	void Update () {
		
	}
}
