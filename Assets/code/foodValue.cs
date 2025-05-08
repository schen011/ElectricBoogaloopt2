using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodvalue : MonoBehaviour
{
    public int foodValue;

    void Start()
    {
        gameFlow.personValue += foodValue;
        Debug.Log(gameFlow.personValue + " " + gameFlow.orderValue);
    }

    
    void Update()
    {
         
    }
}
