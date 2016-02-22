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
        int randomNumber = UnityEngine.Random.Range(0, 3);

        GameObject asteroid;
        if (randomNumber == 0)
        {
            asteroid = (GameObject)Instantiate(smallAsteroid, transform.position, Quaternion.identity);

        }
        else if (randomNumber == 1)
        {
            asteroid = (GameObject)Instantiate(mediumAsteroid, transform.position, Quaternion.identity);
        }
        else if(randomNumber == 2)
        {
            asteroid = (GameObject)Instantiate(largeAsteroid, transform.position, Quaternion.identity);
        }
        else
        {
            asteroid = (GameObject)Instantiate(smallAsteroid, transform.position, Quaternion.identity);
        }
        

        transform.Rotate(GetRandomDirection());
		asteroid.GetComponent<Rigidbody>().velocity = transform.forward * 5;
        asteroid.GetComponent<Asteroid>().AsteroidSpawner = this;
        listOfCurrentAsteroids.Add(asteroid);

	 }

	Vector3 GetRandomDirection()
	{
        //TODO: Test to see if random direction is working
        Vector3 randomDir = new Vector3(0, Random.Range(-30,30),0);
        //print(randomDir);
		return randomDir.normalized;
	}

    public void RemoveAsteroid(GameObject aAsteroid)
    {
        if(listOfCurrentAsteroids.Contains(aAsteroid))
        {
            listOfCurrentAsteroids.Remove(aAsteroid);
        }
        Spawn();
    }


}
