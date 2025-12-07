using UnityEngine;

[CreateAssetMenu(fileName = "GameParameters", menuName = "Scriptable Objects/GameParameters")]
public class GameParameters : ScriptableObject
{
    [SerializeField] private int gameplayDuration;
    
    public int GameplayDuration => gameplayDuration;
    
}
