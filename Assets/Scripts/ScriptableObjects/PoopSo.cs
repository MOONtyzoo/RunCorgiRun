using UnityEngine;

[CreateAssetMenu(fileName = "PoopSo", menuName = "Scriptable Objects/PoopSo")]
public class PoopSo : PlaceableSoBase
{
    [SerializeField] private float poopLifetime;
    [SerializeField] private NumberRange poopSpawnerCooldownRange;

    public override float Lifetime => poopLifetime;
    public override NumberRange SpawnerCooldownRange => poopSpawnerCooldownRange;
}
