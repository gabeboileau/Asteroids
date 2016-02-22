using UnityEngine;
using System.Collections;

public class Ammo_Pickup : MonoBehaviour
{
    private int amountOfAmmo;
    public int maxAmmoDrop = 20;
    public int minAmmoDrop = 5;

    void Awake()
    {
        //Set how much this drop is worth
        StartCoroutine(cr_Rotate());
        amountOfAmmo = UnityEngine.Random.Range(minAmmoDrop, maxAmmoDrop);
    }

    void OnTriggerEnter(Collider aCollider)
    {
        if (aCollider.GetComponent<Bullet_Manager>() != null)
        {
            aCollider.GetComponent<Bullet_Manager>().AddAmmo(amountOfAmmo);
            Destroy(gameObject);
        }
    }

    IEnumerator cr_Rotate()
    {
        while(true)
        {
            transform.Rotate(0, 0, 5);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
