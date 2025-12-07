using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public SpriteRenderer sprite;
    public PlaceableSoBase scriptableObject;
    protected float lifetime;

    protected virtual void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Destroy(gameObject);
        } else if (lifetime <= 1) {
            Fade();
        }
    }

    public virtual void PickUp() {
        Destroy(gameObject);
    }

    void Fade() {
        Color Color = sprite.color;
        Color.a = Mathf.Lerp(0f, 1f, lifetime);
        sprite.color = Color;
    }
}
