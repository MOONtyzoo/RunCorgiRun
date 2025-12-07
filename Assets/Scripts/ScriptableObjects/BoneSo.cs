using UnityEngine;

[CreateAssetMenu(fileName = "BoneSo", menuName = "Scriptable Objects/BoneSo")]
public class BoneSo : PlaceableSoBase
{
    [SerializeField] private float boneLifetime;
    [SerializeField] private NumberRange boneSpawnerCooldownRange;

    public override float Lifetime => boneLifetime;
    public override NumberRange SpawnerCooldownRange => boneSpawnerCooldownRange;
}