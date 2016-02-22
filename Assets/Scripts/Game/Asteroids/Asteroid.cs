using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{

    public GameObject smallAsteroid;
    public GameObject mediumAsteroid;
    public GameObject largeAsteroid;
    public GameObject ammoPickup;

    public short scoreOfLarge = 100;
    public short scoreOfMedium = 50;
    public short scoreOfSmall = 20;


    public enum Type
    {
        Small,
        Medium,
        Large
    }

    public Type asteroidType;

    private int m_CurrentHealth;

    private const int MAX_HEALTH_SMALL = 10;
    private const int MAX_HEALTH_MEDIUM = 20;
    private const int MAX_HEALTH_LARGE = 30;

	private int zBounds = 22;
	private int xBounds = 34;

    private AsteroidSpawner _AsteroidSpawner;
    private AudioSource m_AudioSource;


    public AsteroidSpawner AsteroidSpawner
    {
        set
        {
            _AsteroidSpawner = value;
        }
    }

    void Awake()
	{
        m_AudioSource = GetComponent<AudioSource>();

        switch (asteroidType)
        {
            case Type.Small:
                m_CurrentHealth = MAX_HEALTH_SMALL;
                StartCoroutine(ContinuousRotation(5));
                break;

            case Type.Medium:
                m_CurrentHealth = MAX_HEALTH_MEDIUM;
                StartCoroutine(ContinuousRotation(2));
                break;

            case Type.Large:
                m_CurrentHealth = MAX_HEALTH_LARGE;
                StartCoroutine(ContinuousRotation(1));

                break;
            default:
                Debug.LogError("This asteriod has no type..");
                break;
        }

	}

	void Update()
	{
		CheckBounds();
	}

    public void TakeDamage(int aAmountOfDamage)
    {
        m_CurrentHealth -= aAmountOfDamage;
        //Debug.Log(m_CurrentHealth);
        if (m_CurrentHealth <= 0)
        {
            //Asteroid is dead
            Death();
        }
    }

    void Death()
    {
        //TODO: Particle System

        switch(asteroidType)
        {
            case Type.Large:
                {
                    GameObject asteroid1 = Instantiate(mediumAsteroid, transform.position, Quaternion.identity) as GameObject;
                    GameObject asteroid2 = Instantiate(mediumAsteroid, transform.position, Quaternion.identity) as GameObject;

                    asteroid1.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
                    asteroid2.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;

                    asteroid1.GetComponent<Asteroid>().AsteroidSpawner = _AsteroidSpawner;
                    asteroid2.GetComponent<Asteroid>().AsteroidSpawner = _AsteroidSpawner;

                    Score_Manager.AddScore(scoreOfLarge);
                    Destroy(gameObject);
                }
                
                    break;

            case Type.Medium:
                GameObject asteroid3 = (GameObject)Instantiate(smallAsteroid, transform.position, Quaternion.identity);
                GameObject asteroid4 = (GameObject)Instantiate(smallAsteroid, transform.position, Quaternion.identity);

                asteroid3.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
                asteroid4.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;

                asteroid3.GetComponent<Asteroid>().AsteroidSpawner = _AsteroidSpawner;
                asteroid4.GetComponent<Asteroid>().AsteroidSpawner = _AsteroidSpawner;

                Score_Manager.AddScore(scoreOfMedium);
                Destroy(gameObject);
                break;

            case Type.Small:
                int random = Random.Range(0, 100);
                if(random > 50)
                {
                    GameObject ammo = Instantiate(ammoPickup, transform.position, Quaternion.identity) as GameObject;
                    ammo.transform.Rotate(new Vector3(270, 0, 0));
                }
                _AsteroidSpawner.RemoveAsteroid(gameObject);
                Score_Manager.AddScore(scoreOfSmall);
                
                Destroy(gameObject);
                break;
        }

        //remove from list
    }

	IEnumerator ContinuousRotation(int rotationSpeed)
	{
		Vector3 rotationDirection = Vector3.right;
		while (true)
		{
			transform.Rotate(rotationDirection, rotationSpeed);
			yield return new WaitForSeconds(0.01f);
		}
	}

	void CheckBounds()
	{
		if (transform.position.x > xBounds)
		{
			transform.position = new Vector3(-xBounds, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < -xBounds)
		{
			transform.position = new Vector3(xBounds, transform.position.y, transform.position.z);
		}

		//The up bounds 
		if (transform.position.z > zBounds)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, -zBounds);
		}
		else if (transform.position.z < -zBounds)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, zBounds);
		}
	}

}
