using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerScipt : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private bool hasTimeRunOut = false;

   [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] static float remainingTime = 60f;


    void Update()
    {
        Timer(); 
    }

     public void Timer()
    {
            if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
        else if (!hasTimeRunOut)
        {
            remainingTime = 0;
            hasTimeRunOut = true; // make sure this block only runs once
            timerText.color = Color.red;
            timerText.text = "00 : 00";
            SubtractScore(5);
        }
    }

      public void ResetTimer(float newTime)
    {
        remainingTime = newTime;
        hasTimeRunOut = false;
       timerText.color = Color.white;
        Debug.Log("reset");
    }


    void SubtractScore(int amount)
    {
        servePerson.score -= amount;
        UImanager.instance.UpdateUI();
        scoreText.text = "Score: " + servePerson.score.ToString(); // update TMP text
    }
}
