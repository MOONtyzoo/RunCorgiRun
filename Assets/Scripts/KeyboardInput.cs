using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi corgi;
    public PoopPlacer poopPlacer;

    private Vector2 movementInput = Vector2.zero;
    private Action UpButton;
    private Action DownButton;
    private Action LeftButton;
    private Action RightButton;

    private void Awake()
    {
        corgi.OnStateChanged += OnCorgiStateChanged;
        SetNormalControls();
    }

    private void Update()
    {
        movementInput = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)) UpButton?.Invoke();
        if (Input.GetKey(KeyCode.DownArrow)) DownButton?.Invoke();
        if (Input.GetKey(KeyCode.LeftArrow)) LeftButton?.Invoke();
        if (Input.GetKey(KeyCode.RightArrow)) RightButton?.Invoke();
        movementInput.Normalize();

        new MoveCommand(corgi, movementInput).Execute();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            new PlacePoopCommand(poopPlacer, corgi.transform).Execute();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                new QuitCommand().Execute();
            }
        }
    }

    private void OnCorgiStateChanged(Corgi.States oldState, Corgi.States newState)
    {
        if (newState == Corgi.States.Normal)
        {
            SetNormalControls();
        } 
        else if (newState == Corgi.States.Drunk)
        {
            SetReversedControls();
        }
        else if (newState == Corgi.States.Plastered)
        {
            SetRandomControls();
        }
    }

    private void SetNormalControls()
    {
        UpButton = MoveUpAction;
        DownButton = MoveDownAction;
        LeftButton = MoveLeftAction;
        RightButton = MoveRightAction;
    }

    private void SetReversedControls()
    {
        UpButton = MoveDownAction;
        DownButton = MoveUpAction;
        LeftButton = MoveRightAction;
        RightButton = MoveLeftAction;
    }

    private void SetRandomControls()
    {
        List<Action> actions = new List<Action> { MoveUpAction, MoveDownAction, MoveLeftAction, MoveRightAction };
        
        Action randomAction = actions[UnityEngine.Random.Range(0, actions.Count)];
        UpButton = randomAction;
        actions.Remove(randomAction);
        
        randomAction = actions[UnityEngine.Random.Range(0, actions.Count)];
        DownButton = randomAction;
        actions.Remove(randomAction);
        
        randomAction = actions[UnityEngine.Random.Range(0, actions.Count)];
        LeftButton = randomAction;
        actions.Remove(randomAction);
        
        // Last action remaining
        RightButton = actions[0];
    }
    
    private void MoveUpAction() => movementInput += Vector2.up;
    private void MoveDownAction() => movementInput += Vector2.down;
    private void MoveLeftAction() => movementInput += Vector2.left;
    private void MoveRightAction() => movementInput += Vector2.right;
}
