using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start() {
        scoreText.text = "Score: " + GameStatistics.lastGameScore;
        highScoreText.text = "High Score: " + GameStatistics.GetHighScore();
    }
}
