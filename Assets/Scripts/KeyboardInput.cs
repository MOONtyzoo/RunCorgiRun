using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi corgi;
    public PoopPlacer poopPlacer;

    void Update()
    {
        Vector2 movementInput = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)) movementInput += Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow)) movementInput += Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow)) movementInput += Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow)) movementInput += Vector2.right;
        movementInput.Normalize();
        
        corgi.Move(movementInput);

        if (Input.GetKeyDown(KeyCode.Space)) {
            poopPlacer.Place(corgi.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }
}
