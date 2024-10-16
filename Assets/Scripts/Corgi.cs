using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    
    public new Rigidbody2D rigidbody;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameParameters.CorgiMoveSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        KeepOnScreen();
    }

    void OnCollisionEnter() {
        print("HELLO");
    }

    public void Move(Vector2 moveDir) {
        Vector2 velocity = moveDir*moveSpeed*Time.deltaTime;
        rigidbody.position += velocity;
        TurnSprite(moveDir);
    }

    public void TurnSprite(Vector2 moveDir) {
        if (moveDir.x > 0) {
            sprite.flipX = false;
        } else if (moveDir.x < 0) {
            sprite.flipX = true;
        }
    }

    public void KeepOnScreen() {
        Vector3 constrainedPosition = SpriteTools.ConstrainToScreen(sprite);
        transform.position = constrainedPosition;
    }
}
