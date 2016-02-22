using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	public ParticleSystem explosionParticle;
    public AudioClip explosionSound;


	public int lifeSpan = 3;
    public int damage = 5;

	private int zBounds = 20;
	private int xBounds = 32;
    private AudioSource m_AudioSource;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
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
        gameObject.SetActive(false);
    }

	private void OnTriggerEnter(Collider aCollider)
	{
		if (aCollider.CompareTag("Asteroid"))
		{
			ParticleSystem particle = (ParticleSystem) Instantiate(explosionParticle, transform.position, Quaternion.identity);
            aCollider.GetComponent<Asteroid>().TakeDamage(damage);
            StartCoroutine(cr_DeathTimer(particle));
            m_AudioSource.PlayOneShot(explosionSound);
            gameObject.SetActive(false);
		}
	}
     IEnumerator cr_DeathTimer(ParticleSystem aSystemToDestroy)
    {

        yield return new WaitForSeconds(3.0f);
        Destroy(aSystemToDestroy);
        gameObject.SetActive(false);
    }

}
