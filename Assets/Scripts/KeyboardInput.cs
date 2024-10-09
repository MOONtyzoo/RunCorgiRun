using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi corgi;
    public PoopPlacer poopPlacer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalAxis, verticalAxis).normalized;
        corgi.Move(inputVector);

        if (Input.GetKey(KeyCode.Space)) {
            //PoopPlacer.place();
        }
    }
}
