using UnityEngine;

public class QuitCommand : ICommand
{
    public void Execute()
    {
        Application.Quit();
    }
}

