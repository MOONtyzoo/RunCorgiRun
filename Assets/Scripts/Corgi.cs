using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public float speed = 1.0f;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeepOnScreen();
    }

    public void Move(Vector2 moveDir) {
        Vector2 velocity = moveDir*speed*Time.deltaTime;
        transform.Translate((Vector3)velocity);

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
