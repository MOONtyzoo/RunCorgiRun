using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : Pickup
{
    public void Start()
    {
        lifetime = scriptableObject.Lifetime;
    }
}

