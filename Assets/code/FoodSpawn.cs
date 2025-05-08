using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public List<GameObject> foodSpawn;
    public Transform player; // Reference to the player's Transform

    void Start()
    {
        // Load food items from the Resources folder only once
        foodSpawn = new List<GameObject>(Resources.LoadAll<GameObject>("Food"));
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B)) 
        {
            
            Instantiate(foodSpawn[0], new Vector3(-2.178177f, 1.376199f, 18.8941f), Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.J)) 
        {
           
            Instantiate(foodSpawn[1], new Vector3(-2.178177f, 1.376199f, 18.8941f), Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.N)) 
        {
            
            Instantiate(foodSpawn[2], new Vector3(-2.178177f, 1.376199f, 18.8941f), Quaternion.identity);
        }
         if (Input.GetKey(KeyCode.M)) 
        {
            
            Instantiate(foodSpawn[3], new Vector3(-2.178177f, 1.376199f, 18.8941f), Quaternion.identity);
        } 
        if (Input.GetKey(KeyCode.K)) 
        {
            
            Instantiate(foodSpawn[4], new Vector3(-2.178177f, 1.376199f, 18.8941f), Quaternion.identity);
        }
    }
}
