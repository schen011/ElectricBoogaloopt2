using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class servePerson : MonoBehaviour
{
    public static int score;

    public TextMeshProUGUI scoreText;

    public gameFlow gameflow;

    [SerializeField] private timerScipt timerScript;
    
    [SerializeField] private TextMeshProUGUI timerText;


    private void OnTriggerEnter(Collider other)
    {
      food_script data = other.GetComponent<food_script>();
       if(data != null)
       {
           if (gameFlow.orderValue[data.foodIndex] > 0) 
           {
            gameFlow.personValue += data.foodValue; 
            Debug.Log(gameFlow.personValue + " " + gameFlow.orderValue);
            
                gameFlow.orderValue[data.foodIndex] -= 1;
           }
           
        }

         if(other.CompareTag("Food"))
            {
                Destroy(other.gameObject);
            }

        if(gameFlow.orderValue [0] == 0 && gameFlow.orderValue [1] == 0 && gameFlow.orderValue [2] == 0 && gameFlow.orderValue [3] == 0)  
        {
            Debug.Log("correct" +" "+ gameFlow.orderTimer);
            AddScore(10);
            CustomerManager.Instance.SellToCustomer();
            gameflow.NewOrder();
            timerScript.ResetTimer(gameFlow.orderTimer);   

        }
        else
        {
            Debug.Log("incorrect");
            
        }
    }


    void AddScore(int amount)
    {
        score += amount;
        UImanager.instance.UpdateUI();
        scoreText.text = "Score: " + score.ToString(); // update TMP text
    }

}
