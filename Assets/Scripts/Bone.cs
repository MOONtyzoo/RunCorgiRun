using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : TimedLifeSpan
{
    public void Start() {
        lifetime = GameParameters.BoneLifetime;
    }
}

