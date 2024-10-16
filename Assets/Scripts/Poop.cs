using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Poop : TimedLifeSpan
{
    public void Start() {
        lifetime = GameParameters.PoopLifetime;
    }
}
