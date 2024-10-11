using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public SpriteRenderer poopSprite;
    public float poopLifetime;

    void Update()
    {
        poopLifetime -= Time.deltaTime;
        if (poopLifetime <= 0) {
            Destroy(this);
        } else if (poopLifetime <= 1) {
            FadePoop();
        }
    }

    void FadePoop() {
        Color poopColor = poopSprite.color;
        poopColor.a = Mathf.Lerp(0f, 1f, poopLifetime);
        poopSprite.color = poopColor;
    }
}
