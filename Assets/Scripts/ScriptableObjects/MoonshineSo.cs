using UnityEngine;

[CreateAssetMenu(fileName = "MoonshineSo", menuName = "Scriptable Objects/MoonshineSo")]
public class MoonshineSo : PlaceableSoBase
{
    [SerializeField] private float moonshineFallSpeed;
    [SerializeField] private float moonshineLifetime;
    [SerializeField] private NumberRange moonshineSpawnerCooldownRange;
    [SerializeField] private float moonshineCooldownMultiplierAtGameEnd;

    public float FallSpeed => moonshineFallSpeed;
    public float CooldownMultiplierAtGameEnd => moonshineCooldownMultiplierAtGameEnd;

    public override float Lifetime => moonshineLifetime;
    public override NumberRange SpawnerCooldownRange => moonshineSpawnerCooldownRange;
}

