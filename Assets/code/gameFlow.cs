using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameFlow : MonoBehaviour
{
    public static int [] orderValue = new int [] {0,0,0,0}; // make array 
    public static int personValue = 0000;
    public int maxItems = 5;

    public static float orderTimer = 60f;
    void Start()
    {
        for(int i = maxItems; i > 0; --i)
        {
             orderValue [Random.Range(0,4)] += 1;
        }
        
        for(int i = 0; i < orderValue.Length; i++)

        {

            Debug.Log(orderValue[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {
         orderTimer -=  Time.deltaTime;

        if(orderTimer < 0)
        {
            Debug.Log("Late");
        }

    }
}
