using UnityEngine;
using System.Collections;

public class SpaceShip_Control : MonoBehaviour
{

	public GameObject bullet;
	public int directionValue;

    public int MAX_HEALTH = 100;
    private int m_CurrentHealth;
    public Material mat;

	public int speed = 20;
	public int turnSpeed = 10;
	public ParticleSystem thrusterParticle;

	private LineRenderer m_LineRenderer;

	private const int MAX_SPEED = 10;

    private int zBounds = 20;
	private int xBounds = 32;

	private Bullet_Manager _BulletManager;
	private Rigidbody m_Rigidbody;
    private SpaceShip_SoundControl m_SoundControl;


	void Awake()
	{
        mat.SetColor("_OutlineColor", Color.green);
        m_CurrentHealth = MAX_HEALTH;
		_BulletManager = GetComponent<Bullet_Manager>();
		m_LineRenderer = GetComponent<LineRenderer>();
		m_Rigidbody = GetComponent<Rigidbody>();
        m_SoundControl = GetComponent<SpaceShip_SoundControl>();


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


    void TakeDamage()
    {
        m_SoundControl.Damaged();

        m_CurrentHealth -= 25;
        if (m_CurrentHealth == 75)
        {
            mat.SetColor("_OutlineColor", Color.yellow);
        }
        else if (m_CurrentHealth == 50)
        {
            mat.SetColor("_OutlineColor", Color.magenta);
        }
        else if (m_CurrentHealth == 25)
        {
            mat.SetColor("_OutlineColor", Color.red);
        }
        else if (m_CurrentHealth <= 0)
        {
            //TODO: Implement game over;
            Game_Manager.GameOver();
        }
    }

	void Shoot()
	{
		if (_BulletManager.GetCurrentAmmo() > 0)
		{
            GameObject newBullet = Bullet_Pool.GetBullet();

            newBullet.transform.position = transform.position;
            newBullet.SetActive(true);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 60;
			newBullet.transform.Rotate(transform.forward);
			_BulletManager.RemoveAmmo(1);
            m_SoundControl.Shoot();
		}
		else
		{
			ShowAmmoWarning(); 
		}
	}

	private void ShowAmmoWarning()
	{
	    //TODO: Implement a warning when there is no more ammo when shooting
        	
	}

    void OnTriggerEnter(Collider aCollider)
    {
        if(aCollider.CompareTag("Asteroid"))
        {
            TakeDamage();
        }
    }
}
