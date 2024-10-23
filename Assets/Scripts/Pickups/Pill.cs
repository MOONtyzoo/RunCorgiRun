using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : Pickup
{
    public void Start() {
        lifetime = GameParameters.PillLifetime;
    }
}
