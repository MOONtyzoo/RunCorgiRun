using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance {get; private set;}

    [SerializeField] private UI ui;

    private int score;

    private int secondsInGame;
    private Coroutine gameplayTimerCoroutine;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartGame();        
    }

    public void StartGame() {
        SetScore(0);
        SetSecondsInGame(0);
        StartCoroutine(gameTimer());
    }

    private IEnumerator gameTimer() {
        while (secondsInGame < GameParameters.GameplayDuration) {
            yield return new WaitForSeconds(1);
            SetSecondsInGame(secondsInGame + 1);
        }
        EndGame();
    }

    private void EndGame() {
        GameStatistics.lastGameScore = score;
        if (GameStatistics.lastGameScore > GameStatistics.highScore)
            GameStatistics.highScore = score;
        
        SceneLoader.Load(SceneLoader.Scene.GameOverMenu);
    }

    public void AddScore(int amount) {
        SetScore(score + amount);
    }

    public void SetScore(int newScore) {
        score = newScore;
        ui.UpdateScoreText(score);
    }

    public void SetSecondsInGame(int newSecondsInGame) {
        secondsInGame = newSecondsInGame;
        ui.UpdateTimerText(GameParameters.GameplayDuration - secondsInGame);
    }

    public float GetTimerProgressPercentage() {
        return (float)secondsInGame/GameParameters.GameplayDuration;
    }
}
