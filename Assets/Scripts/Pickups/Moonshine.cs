using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonshine : Pickup
{
    float fallSpeed;
    void Start()
    {
        fallSpeed = GameParameters.MoonshineFallSpeed;
        lifetime = GameParameters.MoonshineLifetime;
    }

    void Update()
    {
        Vector3 velocity = fallSpeed*Vector3.down*Time.deltaTime;
        transform.Translate(velocity);
    }
}
