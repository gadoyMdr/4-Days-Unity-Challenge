using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private float delay = 1f;
    private float timer;

    private int ScoreCount;
    
    public int scoreCount
    {
        get => ScoreCount;
        set
        {
            ScoreCount = value;
            UpdateScoreText();
        }
    }

    private void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (Time.time > timer + delay)
        {
            scoreCount += 1;
            timer = Time.time;
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Score : {scoreCount}";
    }
}
