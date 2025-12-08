using System;
using UnityEngine;

public class CorgiVisual : MonoBehaviour
{
    [SerializeField] private Corgi corgi;
    
    [Header("Sprites")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite drunkSprite;
    [SerializeField] private Color normalColorTint;
    [SerializeField] private Color plasteredColorTint;

    [Header("Particles")]
    [SerializeField] private ParticleSystem drunkParticles;
    [SerializeField] private ParticleSystem plasteredParticles;
    [SerializeField] private ParticleSystem pillParticles;
    [SerializeField] private ParticleSystem boneParticles;
    
    [Header("Trail")]
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private Color normalTrailColor;
    [SerializeField] private Color drunkTrailColor;
    [SerializeField] private Color plasteredTrailColor;
    
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        corgi.OnStateChanged += OnCorgiStateChanged;
        corgi.OnMoved += OnCorgiMoved;
        corgi.OnPickUp += OnPickUp;
    }

    private void OnCorgiStateChanged(Corgi.States oldState, Corgi.States newState)
    {
        if (newState == Corgi.States.Normal)
        {
            spriteRenderer.sprite = normalSprite;
            spriteRenderer.color = normalColorTint;
            drunkParticles.Stop();
            plasteredParticles.Stop();
            SetTrailColor(normalTrailColor);
        }
        else if (newState == Corgi.States.Drunk)
        {
            spriteRenderer.sprite = drunkSprite;
            spriteRenderer.color = normalColorTint;
            drunkParticles.Play();
            SetTrailColor(drunkTrailColor);
        }
        else if (newState == Corgi.States.Plastered)
        {
            spriteRenderer.sprite = drunkSprite;
            spriteRenderer.color = plasteredColorTint;
            drunkParticles.Stop();
            plasteredParticles.Play();
            SetTrailColor(plasteredTrailColor);
        }
    }

    private void OnCorgiMoved(Vector2 moveDelta)
    {
        TurnSprite(moveDelta.normalized);
    }

    private void OnPickUp(string pickupName)
    {
        if (pickupName == "Bone")
        {
            boneParticles.Play();
        }
        else if (pickupName == "Pill")
        {
            pillParticles.Play();
        }
    }
    
    private void TurnSprite(Vector2 moveDir) {
        if (moveDir.x > 0) {
            spriteRenderer.flipX = false;
        } else if (moveDir.x < 0) {
            spriteRenderer.flipX = true;
        }
    }

    private void SetTrailColor(Color color)
    {
        trailRenderer.startColor = color;
        trailRenderer.endColor = color;
    }
}
