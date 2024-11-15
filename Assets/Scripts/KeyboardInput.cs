using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi corgi;
    public PoopPlacer poopPlacer;
    public BeerPlacer beerPlacer;

    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalAxis, verticalAxis).normalized;
        corgi.Move(inputVector);

        if (Input.GetKeyDown(KeyCode.Space)) {
            poopPlacer.Place(corgi.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }
}
