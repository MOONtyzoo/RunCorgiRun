using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance {get; private set;}

    [SerializeField] private UI ui;

    private int score;

    private int secondsInGame;
    private int gameplayDuration = 5;
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
        ui.ShowStartScreen();
        ui.HideGameOverScreen();
    }

    public void StartGame() {
        ui.HideStartScreen();
        ui.HideGameOverScreen();
        ui.ShowGameInfoPanel();
        Reset();
    }

    public void Reset() {
        SetScore(0);
        SetSecondsInGame(0);
        StartCoroutine(gameTimer());
    }

    private IEnumerator gameTimer() {
        while (secondsInGame < gameplayDuration) {
            yield return new WaitForSeconds(1);
            SetSecondsInGame(secondsInGame + 1);
        }
        EndGame();
    }

    private void EndGame() {
        ui.ShowGameOverScreen();
        ui.HideGameInfoPanel();
        if (gameplayTimerCoroutine != null)
            StopCoroutine(gameplayTimerCoroutine);
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
        ui.UpdateTimerText(gameplayDuration - secondsInGame);
    }
}
