using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public ParticleSystem explosionParticle;
	public int lifeSpan = 3;


	private int zBounds = 20;
	private int xBounds = 32;

	void Start()
	{
		StartCoroutine(cr_BulletLife());
	}

	void Update()
	{
		CheckOutOfBounds();
	}


	void CheckOutOfBounds()
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
			transform.position = new Vector3(transform.position.z, transform.position.y, zBounds);
		}
	}


	private IEnumerator cr_BulletLife()
	{
		yield return new WaitForSeconds(lifeSpan);
		GameObject.Destroy(this.gameObject);
	}

	private void OnTriggerEnter(Collider aCollider)
	{
		if (aCollider.CompareTag("Asteroid"))
		{
			ParticleSystem particle = (ParticleSystem) Instantiate(explosionParticle, transform.position, Quaternion.identity);
			Debug.Log("Hit");
			Destroy(this.gameObject);
		}
	}
}
