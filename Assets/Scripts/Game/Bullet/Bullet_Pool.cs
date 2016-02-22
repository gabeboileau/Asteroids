using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet_Pool : MonoBehaviour
{

    public static GameObject bulletPrefab;
    public GameObject bulletObject;
    public Vector3 poolSpawn;
    private static List<GameObject> m_ListOfBullets;
    

    void Start()
    {
        //Create the pool of bullets
        bulletPrefab = bulletObject;
        m_ListOfBullets = new List<GameObject>();

        for (int i = 0; i < 40; i++)
        {
            GameObject bulletToAdd = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            bulletToAdd.SetActive(false);
            m_ListOfBullets.Add(bulletToAdd);
        }

    }

    public static GameObject GetBullet()
    {
        
        for (int i = 0; i < m_ListOfBullets.Count; i++)
        {
            if(m_ListOfBullets[i].activeSelf == false)
            {
                return m_ListOfBullets[i];
            }
        }

        GameObject bullet = Instantiate(bulletPrefab);
        m_ListOfBullets.Add(bullet);
        return bullet;
    }

}
