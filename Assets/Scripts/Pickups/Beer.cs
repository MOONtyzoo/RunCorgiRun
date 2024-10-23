using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : Pickup
{
    public void Start() {
        lifetime = GameParameters.BeerLifetime;
    }
}
