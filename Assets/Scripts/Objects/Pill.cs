using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : TimedLifeSpan
{
    public void Start() {
        lifetime = GameParameters.PillLifetime;
    }
}
