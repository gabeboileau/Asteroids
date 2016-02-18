using UnityEngine;
using System.Collections;

public class SpaceShip_Control : MonoBehaviour
{

	public const int MAX_SPEED = 10;
	public GameObject bullet;
	public int directionValue;

	public int speed = 20;
	public int turnSpeed = 10;
	public ParticleSystem thrusterParticle;
	//public ParticleEmitter partliceEmitter;

	private LineRenderer m_LineRenderer;

	private int zBounds = 20;
	private int xBounds = 32;

	private Bullet_Manager _BulletManager;
	private Rigidbody m_Rigidbody;

	void Awake()
	{
		_BulletManager = GetComponent<Bullet_Manager>();
		m_LineRenderer = GetComponentInChildren<LineRenderer>();
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		CheckOutOfBounds();
		if (Input.GetKeyDown(KeyCode.Space))
		{

			Shoot();
		}
	}

	void FixedUpdate()
	{
		//Clamp the max speed of the spaceship
		speed = Mathf.Clamp(speed, 0, MAX_SPEED);


		if (Input.GetKey(KeyCode.UpArrow))
		{
			thrusterParticle.enableEmission = true;
			m_Rigidbody.AddForce(transform.forward*speed);
		}
		else
		{
			thrusterParticle.enableEmission = false;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			m_Rigidbody.angularVelocity = new Vector3(0, 10.0f, 0);
			//m_Rigidbody.AddTorque(new Vector3(0, Mathf.Clamp(turnSpeed,5,20), 0));
		}

		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			//m_Rigidbody.AddRelativeTorque(-new Vector3(0, Mathf.Clamp(turnSpeed, 5, 20), 0));
			m_Rigidbody.angularVelocity = new Vector3(0, -10.0f, 0);
		}
		else
		{
			m_Rigidbody.angularVelocity = Vector3.zero;
			
		}
	}

	void CheckOutOfBounds()
	{
		if (transform.position.x > xBounds)
		{
			Debug.Log("Working");
			transform.position = new Vector3(-xBounds, transform.position.y, transform.position.z);
			//m_LineRenderer.enabled = true;
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

	void Shoot()
	{
		if (_BulletManager.GetCurrentAmmo() > 0)
		{
			GameObject newBullet = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
			newBullet.GetComponent<Rigidbody>().velocity = transform.forward*60;
			newBullet.transform.Rotate(transform.forward);
			_BulletManager.RemoveAmmo(1);
		}
		else
		{
			ShowAmmoWarning();
		}
	}

	private void ShowAmmoWarning()
	{
		
	}
}
