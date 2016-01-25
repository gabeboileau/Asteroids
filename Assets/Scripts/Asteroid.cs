using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
	private int zBounds = 20;
	private int xBounds = 32;

	void Awake()
	{
		StartCoroutine(ContinuousRotation());
	}

	void Update()
	{
		CheckBounds();
	}

	IEnumerator ContinuousRotation()
	{
		Vector3 rotationDirection = Vector3.right;
		while (true)
		{
			transform.Rotate(rotationDirection, 5);
			yield return new WaitForSeconds(0.05f);
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
