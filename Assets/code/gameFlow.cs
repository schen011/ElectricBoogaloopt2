using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameFlow : MonoBehaviour
{
    public static int [] orderValue = new int [] {0,0,0,0}; // make array 
    public static int personValue = 0000;
    public static int maxItems = 1;

    public static float orderTimer = 60f;

    

    void Start()
    {
      NewOrder();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void NewOrder()
    {
         for(int i = maxItems; i > 0; --i)
        {
             orderValue [Random.Range(0,4)] += 1;
        }
        
        for(int i = 0; i < orderValue.Length; i++)

        {
            Debug.Log(orderValue[i]);
        }
          Debug.Log("neworder");

    }

}
