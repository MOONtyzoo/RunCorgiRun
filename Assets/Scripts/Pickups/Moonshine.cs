using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonshine : Pickup
{
    float fallSpeed;
    private MoonshineSo MoonshineSettings => (MoonshineSo)scriptableObject;
    void Start()
    {
        fallSpeed = MoonshineSettings.FallSpeed;
        lifetime = scriptableObject.Lifetime;
    }

    protected override void Update()
    {
        base.Update();
        Vector3 velocity = fallSpeed*Vector3.down*Time.deltaTime;
        transform.Translate(velocity);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Poop") {
            PickUp();
            Poop poop = other.gameObject.GetComponent<Poop>();
            poop.PickUp();
        }
    }
}
