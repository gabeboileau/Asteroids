using UnityEngine;
using System.Collections;

public class Particle_Death : MonoBehaviour
{
    public int deathTimer = 3;


    void Start()
    {
        StartCoroutine(cr_DeathOverTime());

    }


    IEnumerator cr_DeathOverTime()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }
}
