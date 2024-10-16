using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLifeSpan : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float lifetime;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Destroy(this);
        } else if (lifetime <= 1) {
            Fade();
        }
    }

    void Fade() {
        Color Color = sprite.color;
        Color.a = Mathf.Lerp(0f, 1f, lifetime);
        sprite.color = Color;
    }
}
