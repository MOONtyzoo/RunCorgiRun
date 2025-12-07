using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "Scriptable Objects/PlayerParameters")]
public class PlayerParameters : ScriptableObject
{
    [SerializeField] private float corgiMoveSpeed;
    [SerializeField] private float corgiDrunkenMoveSpeed;
    [SerializeField] private float corgiPlasteredMoveSpeed;
    [SerializeField] private float corgiDrunkSeconds;
    
    public float CorgiMoveSpeed => corgiMoveSpeed;
    public float CorgiDrunkenMoveSpeed => corgiDrunkenMoveSpeed;
    public float CorgiPlasteredMoveSpeed => corgiPlasteredMoveSpeed;
    public float CorgiDrunkSeconds => corgiDrunkSeconds;
}
