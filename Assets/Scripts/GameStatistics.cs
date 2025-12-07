using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatistics
{
    public static int lastGameScore = 0;
    
    private static readonly string highScoreSaveKey = "highScore";

    public static int GetHighScore()  => PlayerPrefs.GetInt(highScoreSaveKey, 0);
    public static void SetHighScore(int newHighScore) => PlayerPrefs.SetInt(highScoreSaveKey, newHighScore);
}
