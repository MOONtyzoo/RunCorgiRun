using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite drunkSprite;

    private float moveSpeed;
    private float drunkenMoveSpeed;
    private float plasteredMoveSpeed;
    private float drunkSeconds;

    private bool isDrunk = false;
    private bool isPlastered = false;
    private Coroutine countdownUntilSoberCoroutine;

    private Vector2 lastRandomMoveDirection = Vector2.zero;
    private float randomMoveCountdownLength = 0.1f;
    private float randomMoveCounter = 0.0f;

    void Start()
    {
        moveSpeed = GameParameters.CorgiMoveSpeed;
        drunkenMoveSpeed = GameParameters.CorgiDrunkenMoveSpeed;
        plasteredMoveSpeed = GameParameters.CorgiPlasteredMoveSpeed;
        drunkSeconds = GameParameters.CorgiDrunkSeconds;
    }

    void Update()
    {
        KeepOnScreen();
        UpdateRandomMoveDirection();
        if (isPlastered) {
            Move(lastRandomMoveDirection);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Beer") {
            GetDrunk();
        } else if (other.tag == "Moonshine") {
            GetPlastered();
        } else if (other.tag == "Pill") {
            SoberUp();
        } else if (other.tag == "Bone") {
            Game.Instance.AddScore(1);
        }

        if (other.tag == "Beer" || other.tag == "Moonshine" || other.tag == "Bone" || other.tag == "Pill") {
            Pickup pickup = other.gameObject.GetComponent<Pickup>();
            pickup.PickUp();
        }
    }

    private void GetDrunk() {
        if (!isDrunk) {
            isDrunk = true;
            spriteRenderer.sprite = drunkSprite;
            countdownUntilSoberCoroutine = StartCoroutine(CountdownUntilSober());
        }
    }

    private IEnumerator CountdownUntilSober() {
        yield return new WaitForSeconds(drunkSeconds);
        SoberUp();
    }

    private void GetPlastered() {
        if (!isPlastered) {
            isPlastered = true;
            spriteRenderer.sprite = drunkSprite;
            countdownUntilSoberCoroutine = StartCoroutine(CountdownUntilSober());
        }
    }

    private void SoberUp() {
        if (isDrunk || isPlastered) {
            isDrunk = false;
            isPlastered = false;
            spriteRenderer.sprite = normalSprite;
            StopCoroutine(countdownUntilSoberCoroutine);
        }
    }

    public void Move(Vector2 moveDir) {
        float speed = 0;
        if (isPlastered) {
            speed = plasteredMoveSpeed;
        } else if (isDrunk) {
            speed = drunkenMoveSpeed;
        } else {
            speed = moveSpeed;
        }
        Vector2 velocity = moveDir*speed*Time.deltaTime;
        
        rigidbody.position += velocity;
        TurnSprite(moveDir);
    }

    public void UpdateRandomMoveDirection() {
        randomMoveCounter -= Time.deltaTime;
        if (randomMoveCounter <= 0) {
            randomMoveCounter = randomMoveCountdownLength;
            lastRandomMoveDirection = GetRandomDirection();
        }
    }

    public Vector2 GetRandomDirection() {
        int randomAngle = Random.Range(-180, 180);
        Vector2 randomDir = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;
        return randomDir;
    }

    public void TurnSprite(Vector2 moveDir) {
        if (moveDir.x > 0) {
            spriteRenderer.flipX = false;
        } else if (moveDir.x < 0) {
            spriteRenderer.flipX = true;
        }
    }

    public void KeepOnScreen() {
        Vector3 constrainedPosition = SpriteTools.ConstrainToScreen(spriteRenderer);
        transform.position = constrainedPosition;
    }
}
