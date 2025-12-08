using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Poop : Pickup
{
    public void Start()
    {
        lifetime = scriptableObject.Lifetime;
    }

    public override void PickUp() { }
}
