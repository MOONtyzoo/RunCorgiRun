using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    private float moveSpeed;
    private float drunkSeconds;
    
    public new Rigidbody2D rigidbody;

    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite drunkSprite;

    private bool isDrunk = false;
    private Coroutine countdownUntilSoberCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameParameters.CorgiMoveSpeed;
        drunkSeconds = GameParameters.CorgiDrunkSeconds;
        
    }

    // Update is called once per frame
    void Update()
    {
        KeepOnScreen();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Beer") {
            GetDrunk();
        } else if (other.tag == "Bone") {

        } else if (other.tag == "Pill") {
            SoberUp();
        } else if (other.tag == "Moonshine") {
            print("moonshine consumed");
        }

        if (other.tag == "Beer" || other.tag == "Bone" || other.tag == "Pill") {
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

    private void SoberUp() {
        if (isDrunk) {
            isDrunk = false;
            spriteRenderer.sprite = normalSprite;
            StopCoroutine(countdownUntilSoberCoroutine);
        }
    }

    public void Move(Vector2 moveDir) {
        Vector2 velocity = moveDir*moveSpeed*Time.deltaTime;
        if (isDrunk) { velocity *= 0.5f; }
        rigidbody.position += velocity;
        TurnSprite(moveDir);
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
