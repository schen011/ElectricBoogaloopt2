using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnbuger : MonoBehaviour
{
    public GameObject burger;

    public int foodValue;

    public Transform spawnpoint;

    public void SpawnBurger()
    {
        GameObject newBurger = Instantiate(burger , spawnpoint);

        food_script data = newBurger.GetComponent<food_script>();
        if (data != null)
        {
            data.foodValue += foodValue;
        }
    }
}

