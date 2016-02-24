using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet_Manager : MonoBehaviour
{
	public Text ammoText;

	private const int MIN_AMMO = 50;
	private int m_CurrentAmmo;
    private SpaceShip_SoundControl m_SoundControl;

	void Start()
    {
        m_SoundControl = GetComponent<SpaceShip_SoundControl>();

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
        else if(m_CurrentAmmo > 6)
        {
            ammoText.color = Color.white;
        }

		ammoText.text = m_CurrentAmmo.ToString();
	}

	public void AddAmmo(int aAmountOfAmmo)
	{
        m_SoundControl.PickUp();
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
