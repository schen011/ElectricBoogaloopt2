using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateUI()
    {
        scoreText.text = "Score : " + servePerson.score;
    }
}
