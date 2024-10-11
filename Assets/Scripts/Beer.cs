using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    public SpriteRenderer beerSprite;
    public float beerLifetime;

    void Update()
    {
        beerLifetime -= Time.deltaTime;
        if (beerLifetime <= 0) {
            Destroy(this);
        } else if (beerLifetime <= 1) {
            Fadebeer();
        }
    }

    void Fadebeer() {
        Color beerColor = beerSprite.color;
        beerColor.a = Mathf.Lerp(0f, 1f, beerLifetime);
        beerSprite.color = beerColor;
    }
}
