using UnityEngine;
using System.Collections;

public class AmmoLevel : MonoBehaviour
{
    public static int currentAmmoPickups;

    public static int GetAmmoPickupCount()
    {
        return currentAmmoPickups;
    }
    
    public static void RemoveAmmoPickup()
    {
        currentAmmoPickups--;
        print(currentAmmoPickups + " Remved");
    }

    public static void AddAmmoPickup()
    {

        currentAmmoPickups++;
        print(currentAmmoPickups + " ADDED");
    }
}
