using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        GameManager.instance.OnTimer += OnTimer;
        GameManager.instance.OnScore += OnScore;
    }

    void OnTimer()
    {
        timerText.text = $"Time : {GameManager.instance.timeLeft:0}";
    }

    void OnScore()
    {
        scoreText.text = $"Score : {GameManager.instance.score}";
    }
}
