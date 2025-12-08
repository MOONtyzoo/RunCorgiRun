using UnityEngine;

public class MoveCommand : ICommand
{
    private readonly Corgi corgi;
    private readonly Vector2 direction;

    public MoveCommand(Corgi corgi, Vector2 direction)
    {
        this.corgi = corgi;
        this.direction = direction;
    }

    public void Execute()
    {
        corgi.Move(direction);
    }
}