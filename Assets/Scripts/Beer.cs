using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : TimedLifeSpan
{
    public void Start() {
        lifetime = GameParameters.BeerLifetime;
    }
}
