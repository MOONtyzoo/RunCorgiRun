using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject startScreenPanel;
    [SerializeField] private GameObject gameOverScreenPanel;
    [SerializeField] private GameObject gameInfoPanel;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;

    public void ShowStartScreen() {
        startScreenPanel.SetActive(true);
    }

    public void HideStartScreen() {
        startScreenPanel.SetActive(false);
    }

    public void ShowGameOverScreen() {
        gameOverScreenPanel.SetActive(true);
    }

    public void HideGameOverScreen() {
        gameOverScreenPanel.SetActive(false);
    }

    public void ShowGameInfoPanel() {
        gameInfoPanel.SetActive(true);
    }

    public void HideGameInfoPanel() {
        gameInfoPanel.SetActive(false);
    }

    public void UpdateScoreText(int score) {
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimerText(int timeInSeconds) {
        int seconds = timeInSeconds % 60;
        int minutes = (timeInSeconds) / 60;

        timerText.text = GetTimeAsString(timeInSeconds);
    }

    public string GetTimeAsString(int timeInSeconds) {
        int seconds = timeInSeconds % 60;
        int minutes = (timeInSeconds) / 60;

        string secondsText = (timeInSeconds % 60).ToString();
        if (secondsText.Length == 1) {
            secondsText = "0" + secondsText;
        }

        string minutesText = minutes.ToString();

        return minutesText + ":" + secondsText;
    }
}
