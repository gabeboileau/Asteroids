using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
	public GameObject smallAsteroid;
	public GameObject mediumAsteroid;
	public GameObject largeAsteroid;

	public GameObject playerRef;
	public List<GameObject> listOfCurrentAsteroids;

	public enum AsteroidType
	{
		Large, 
		Medium,
		Small
	}

	void Start()
	{
		listOfCurrentAsteroids = new List<GameObject>();
		Spawn();
	}

	 void Spawn()
	 {
		gameObject.transform.Rotate(new Vector3(0, UnityEngine.Random.Range(-40, 40), 0));

		GameObject asteroid = (GameObject)Instantiate(smallAsteroid, transform.position, Quaternion.identity);
		 asteroid.GetComponent<Rigidbody>().velocity = transform.forward * 5;
		// Debug.Log(transform.rotation);
		
	 }

	Vector3 GetDirectionToPlayer()
	{
		Vector3 directionToPlayer = (playerRef.transform.position - transform.position).normalized;
		return directionToPlayer;
	}




}
