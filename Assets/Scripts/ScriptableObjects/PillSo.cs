using UnityEngine;

[CreateAssetMenu(fileName = "PillSo", menuName = "Scriptable Objects/PillSo")]
public class PillSo : PlaceableSoBase
{
    [SerializeField] private float pillLifetime;
    [SerializeField] private NumberRange pillSpawnerCooldownRange;
    
    public override float Lifetime => pillLifetime;
    public override NumberRange SpawnerCooldownRange => pillSpawnerCooldownRange;

    
}
