using UnityEngine;

public abstract class PlaceableSoBase : ScriptableObject
{
    public abstract NumberRange SpawnerCooldownRange { get; }
    public abstract float Lifetime { get; }
}
