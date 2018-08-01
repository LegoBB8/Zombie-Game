using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomSpawner : MonoBehaviour {

	public GameObject spawnObject;
	public Transform[] spawnPoint;
	public float startDelay=0;
	public float timeInterval=5;
	public float spawnCount=10;
	float nextSpawnTime=0;
	float currentCount=0;
	bool spawnStart=false;
	public UnityEvent finishedEvent;

	void Start () {
		Invoke ("SpawnStart", startDelay);
	}
	
	void Update () {
		if (currentCount < spawnCount && spawnStart) {
			if (Time.time >= nextSpawnTime) {
				Transform spawnTransform = spawnPoint [Random.Range (0, spawnPoint.Length)];
				Instantiate (spawnObject, spawnTransform.position, spawnTransform.rotation);
				nextSpawnTime = Time.time + timeInterval;
				currentCount++;
				if (currentCount == spawnCount)
					finishedEvent.Invoke ();
			}
		}
	}

	void SpawnStart () {
		spawnStart = true;
	}
}
