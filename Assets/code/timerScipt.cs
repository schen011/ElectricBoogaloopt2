using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerScipt : MonoBehaviour
{
    public static int score;

    public TextMeshProUGUI scoreText;

    private bool hasTimeRunOut = false;

   [SerializeField] TextMeshProUGUI timerText;
    [SerializeField]float remainingTime;


    void Update()
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

    void SubtractScore(int amount)
    {
        score -= amount;
        UImanager.instance.UpdateUI(score);
        scoreText.text = "Score: " + score.ToString(); // update TMP text
    }
}
