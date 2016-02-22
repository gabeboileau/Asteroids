using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

	private LineRenderer m_LineRenderer;


	void Start()
	{
		m_LineRenderer = GetComponent<LineRenderer>();
		
	}


	void Update ()
	{

		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit))
		{
			if (hit.collider != null && hit.collider.CompareTag("Bullet") == false && hit.collider.CompareTag("Ammo_Pickup") == false)
			{
				m_LineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
			}
		}
		else
		{
			m_LineRenderer.SetPosition(1, new Vector3(0, 0, 100));
		}

	}
}
