using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet_Manager : MonoBehaviour
{
	public Text ammoText;

	private const int MAX_AMMO = 1000;
	private const int MIN_AMMO = 20;

	private int m_CurrentAmmo;


	void Start()
	{
		m_CurrentAmmo = MIN_AMMO;
		UpdateAmmoText();
	}

	void UpdateAmmoText()
	{
		if (m_CurrentAmmo < 5 && m_CurrentAmmo > 1)
		{
			ammoText.color = Color.yellow;

		}
		else if (m_CurrentAmmo <= 1)
		{
			ammoText.color = Color.red;
		}

		ammoText.text = m_CurrentAmmo.ToString();
	}

	public void AddAmmo(int aAmountOfAmmo)
	{
		m_CurrentAmmo += aAmountOfAmmo;
		UpdateAmmoText();

	}

	public void RemoveAmmo(int aAmountToRemove)
	{
		m_CurrentAmmo -= aAmountToRemove;
		UpdateAmmoText();
	}


	public int GetCurrentAmmo()
	{
		return m_CurrentAmmo;
	}
} 
