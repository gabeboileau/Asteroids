using UnityEngine;
using System.Collections;

public class SpaceShip_SoundControl : MonoBehaviour
{
    public AudioClip damaged;
    public AudioClip laser;
    public AudioClip pickup;

    private AudioSource m_AudioSource;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        m_AudioSource.PlayOneShot(laser);
    }

    public void Damaged()
    {
        m_AudioSource.PlayOneShot(damaged);
    }

    public void PickUp()
    {
        m_AudioSource.PlayOneShot(pickup);
    }
}
