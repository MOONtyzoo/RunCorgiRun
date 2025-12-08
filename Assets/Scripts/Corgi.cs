using System;
using System.Collections;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public event Action<States, States> OnStateChanged;
    public event Action<Vector2> OnMoved;
    public event Action<string> OnPickUp;
    public event Action<int> OnScoreChanged;

    [SerializeField] private PlayerParameters playerParameters;
    
    private Rigidbody2D rbody;
    
    private Coroutine countdownUntilSoberCoroutine;

    public enum States
    {
        Normal,
        Drunk,
        Plastered,
    }
    private States state = States.Normal;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SwitchState(States.Normal);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Beer")) 
        {
            GetDrunk();
            OnPickUp?.Invoke("Beer");
        }
        else if (other.CompareTag("Moonshine")) 
        {
            GetPlastered();
            Game.Instance.AddScore(-5);
            ScoreFloaterSpawner.Instance.SpawnScoreFloater(other.transform.position, -5);
            OnPickUp?.Invoke("Moonshine");
        }
        else if (other.CompareTag("Pill")) 
        {
            SoberUp();
            OnPickUp?.Invoke("Pill");
        }
        else if (other.CompareTag("Bone"))
        {
            int scoreGain = state == States.Drunk ? 2 : 1;
            Game.Instance.AddScore(scoreGain);
            ScoreFloaterSpawner.Instance.SpawnScoreFloater(other.transform.position, scoreGain);
            OnPickUp?.Invoke("Bone");
            OnScoreChanged?.Invoke(1);
        }

        if (other.TryGetComponent(out Pickup pickup)) {
            pickup.PickUp();
        }
    }
    
    public void Move(Vector2 moveDir) {
        Vector2 velocity = moveDir*playerParameters.MoveSpeed;
        Vector2 movementDelta = velocity * Time.deltaTime;
        rbody.position += movementDelta;
        OnMoved?.Invoke(movementDelta);
    }

    private void GetDrunk() {
        if (state == States.Normal)
        {
            SwitchState(States.Drunk);
            countdownUntilSoberCoroutine = StartCoroutine(CountdownUntilSober());
        }
    }
    private void GetPlastered() {
        if (state != States.Plastered)
        {
            SwitchState(States.Plastered);
            countdownUntilSoberCoroutine = StartCoroutine(CountdownUntilSober());
        }
    }

    private IEnumerator CountdownUntilSober() {
        yield return new WaitForSeconds(playerParameters.DrunkDuration);
        SoberUp();
    }

    private void SoberUp() {
        if (state == States.Drunk || state == States.Plastered)
        {
            SwitchState(States.Normal);
            StopCoroutine(countdownUntilSoberCoroutine);
        }
    }
    
    private void SwitchState(States newState)
    {
        OnStateChanged?.Invoke(state, newState);
        state = newState;
    }
}
