using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI timerText, coinsText, scoreText;
    private static int maxTime, coins, score;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        int intTime = maxTime - (int) (Time.realtimeSinceStartup * 2.5f);
        String timeStr = $"Time \n {intTime}";
        timerText.text = timeStr;

        String coinStr = $"Coins \n {coins}";
        coinsText.text = coinStr;

        String scoreStr = $"Score \n {score}";
        scoreText.text = scoreStr;
    }

    public static void addCoin()
    {
        coins++;
    }
}
