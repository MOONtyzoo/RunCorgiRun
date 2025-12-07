using System;
using UnityEngine;

public class CorgiVisual : MonoBehaviour
{
    [SerializeField] private Corgi corgi;
    
    [Header("Sprites")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite drunkSprite;

    [Header("Particles")]
    [SerializeField] private ParticleSystem drunkParticles;
    [SerializeField] private ParticleSystem plasteredParticles;
    
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        corgi.OnStateChanged += OnCorgiStateChanged;
        corgi.OnMoved += OnCorgiMoved;
    }

    private void OnCorgiStateChanged(Corgi.States oldState, Corgi.States newState)
    {
        if (newState == Corgi.States.Normal)
        {
            spriteRenderer.sprite = normalSprite;
            drunkParticles.Stop();
            plasteredParticles.Stop();
        }
        else if (newState == Corgi.States.Drunk)
        {
            spriteRenderer.sprite = drunkSprite;
            drunkParticles.Play();
        }
        else if (newState == Corgi.States.Plastered)
        {
            spriteRenderer.sprite = drunkSprite;
            drunkParticles.Stop();
            plasteredParticles.Play();
        }
    }

    private void OnCorgiMoved(Vector2 moveDelta)
    {
        TurnSprite(moveDelta.normalized);
    }
    
    private void TurnSprite(Vector2 moveDir) {
        if (moveDir.x > 0) {
            spriteRenderer.flipX = false;
        } else if (moveDir.x < 0) {
            spriteRenderer.flipX = true;
        }
    }
}
