using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour
{
	public SpaceShip_Control _SpaceShip;
	private Renderer m_Renderer;
	private Material m_Material;

	void Start()
	{
		m_Renderer = GetComponent<Renderer>();
		m_Material = m_Renderer.material;
	}

	void Update()
	{
		m_Material.SetFloat("_Direction", _SpaceShip.directionValue);
	}

}
