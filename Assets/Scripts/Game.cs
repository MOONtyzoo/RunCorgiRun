using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance {get; private set;}
    public event Action<int> OnSecondPassed;
    public event Action<int> OnScoreChanged;
    public event Action OnGameStart;
    public event Action OnGameOver;
    
    

    [SerializeField] private UI ui;
    [SerializeField] private GameParameters gameParameters;
    [SerializeField] private Corgi player;


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
        OnGameStart += StartSetup;
        OnGameOver += EndGame;
        StartGame();        
    }

    private void StartGame() {
        OnGameStart?.Invoke();
        OnSecondPassed?.Invoke(0);
    }

    private void StartSetup()
    {
        SetScore(0);
        StartCoroutine(gameTimer());
    }

    private IEnumerator gameTimer() {
        while (secondsInGame < gameParameters.GameplayDuration) {
            yield return new WaitForSeconds(1);
            OnSecondPassed?.Invoke(secondsInGame + 1);
            secondsInGame++;
        }
        OnGameOver?.Invoke();
    }

    private void EndGame() {
        if (score > GameStatistics.GetHighScore())
            GameStatistics.SetHighScore(score);
        GameStatistics.lastGameScore = score;
        
        SceneLoader.Load(SceneLoader.Scene.GameOverMenu);
    }

    public void AddScore(int amount) {
        SetScore(score + amount);
    }

    private void SetScore(int newScore) {
        score = newScore;
        score = Mathf.Clamp(score, 0, int.MaxValue);
        OnScoreChanged?.Invoke(score);
    }

    public float GetTimerProgressPercentage() {
        return (float)secondsInGame/gameParameters.GameplayDuration;
    }
}
