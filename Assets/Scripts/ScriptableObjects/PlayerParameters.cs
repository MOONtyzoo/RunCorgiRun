using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "Scriptable Objects/PlayerParameters")]
public class PlayerParameters : ScriptableObject
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float drunkDuration;
    
    public float MoveSpeed => moveSpeed;
    public float DrunkDuration => drunkDuration;
}
