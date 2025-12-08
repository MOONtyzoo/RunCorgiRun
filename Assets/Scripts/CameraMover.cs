using System;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Corgi corgi;
    
    [Header("Camera Settings")]
    [SerializeField] private float wobbleRotationFactor;

    [SerializeField] private float smoothingSpeed;
    
    [Header("Drunk")]
    [SerializeField] private float drunkWobbleAmplitude;
    [SerializeField] private float drunkWobbleFrequency;
    
    [Header("Plastered")]
    [SerializeField] private float plasteredWobbleAmplitude;
    [SerializeField] private float plasteredWobbleFrequency;

    private float wobbleAmplitude = 0.0f;
    private float wobbleFrequency = 0.0f;

    private float offsetY = 0.0f;
    private float rotationZ = 0.0f;

    private void Awake()
    {   
        corgi.OnStateChanged += OnCorgiStateChanged;
    }

    private void Update()
    {
        float targetOffsetY = Mathf.Sin(Time.time * wobbleFrequency) * wobbleAmplitude;
        offsetY = Mathf.Lerp(offsetY, targetOffsetY, smoothingSpeed * Time.deltaTime);
        Vector3 newPosition = new Vector3(0.0f, offsetY, -10.0f);
        
        float targetRotationZ = Mathf.Cos(Time.time * wobbleFrequency) * wobbleAmplitude * wobbleRotationFactor;
        rotationZ = Mathf.Lerp(rotationZ, targetRotationZ, smoothingSpeed * Time.deltaTime);
        Quaternion newRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        transform.SetPositionAndRotation(newPosition, newRotation);
    }

    private void OnCorgiStateChanged(Corgi.States oldState, Corgi.States newState)
    {
        if (newState == Corgi.States.Normal)
        {
            wobbleAmplitude = 0.0f;
            wobbleFrequency = 0.0f;
        }
        else if (newState == Corgi.States.Drunk)
        {
            wobbleAmplitude = drunkWobbleAmplitude;
            wobbleFrequency = drunkWobbleFrequency;
        }
        else if (newState == Corgi.States.Plastered)
        {
            wobbleAmplitude = plasteredWobbleAmplitude;
            wobbleFrequency = plasteredWobbleFrequency;
        }
    }
}
