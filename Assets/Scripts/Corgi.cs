using System;
using System.Collections;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public event Action<States, States> OnStateChanged;

    [SerializeField] private PlayerParameters playerParameters;
    
    private Rigidbody2D rbody;

    [Header("Sprite")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite drunkSprite;
    
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
        }
        else if (other.CompareTag("Moonshine")) 
        {
            GetPlastered();
        }
        else if (other.CompareTag("Pill")) 
        {
            SoberUp();
        }
        else if (other.CompareTag("Bone")) 
        {
            Game.Instance.AddScore(1);
        }

        if (other.TryGetComponent(out Pickup pickup)) {
            pickup.PickUp();
        }
    }
    
    public void Move(Vector2 moveDir) {
        Vector2 velocity = moveDir*playerParameters.MoveSpeed;
        rbody.position += velocity * Time.deltaTime;
        TurnSprite(moveDir);
    }

    private void GetDrunk() {
        if (state == States.Normal)
        {
            SwitchState(States.Drunk);
            spriteRenderer.sprite = drunkSprite;
            countdownUntilSoberCoroutine = StartCoroutine(CountdownUntilSober());
        }
    }
    private void GetPlastered() {
        if (state != States.Plastered)
        {
            SwitchState(States.Plastered);
            spriteRenderer.sprite = drunkSprite;
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
            spriteRenderer.sprite = normalSprite;
            StopCoroutine(countdownUntilSoberCoroutine);
        }
    }
    
    private void SwitchState(States newState)
    {
        OnStateChanged?.Invoke(state, newState);
        state = newState;
    }

    private void TurnSprite(Vector2 moveDir) {
        if (moveDir.x > 0) {
            spriteRenderer.flipX = false;
        } else if (moveDir.x < 0) {
            spriteRenderer.flipX = true;
        }
    }
}
