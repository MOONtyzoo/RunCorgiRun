using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI debugStateText;

    [SerializeField] private Corgi player;

    private void Awake()
    {
        player.OnStateChanged += OnPlayerStateChanged;
    }

    public void UpdateScoreText(int score) {
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimerText(int timeInSeconds) {
        int seconds = timeInSeconds % 60;
        int minutes = (timeInSeconds) / 60;

        timerText.text = GetTimeAsString(timeInSeconds);
    }

    private string GetTimeAsString(int timeInSeconds) {
        int seconds = timeInSeconds % 60;
        int minutes = (timeInSeconds) / 60;

        string secondsText = (timeInSeconds % 60).ToString();
        if (secondsText.Length == 1) {
            secondsText = "0" + secondsText;
        }

        string minutesText = minutes.ToString();

        return minutesText + ":" + secondsText;
    }

    private void OnPlayerStateChanged(Corgi.States oldState, Corgi.States newState)
    {
        debugStateText.text = newState.ToString();
    }
}
