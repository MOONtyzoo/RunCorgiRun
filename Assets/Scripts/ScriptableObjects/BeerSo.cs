using UnityEngine;

[CreateAssetMenu(fileName = "BeerSo", menuName = "Scriptable Objects/BeerSo")]
public class BeerSo : PlaceableSoBase
{
    [SerializeField] private float beerLifetime;
    [SerializeField] private NumberRange beerSpawnerCooldownRange;

    public override float Lifetime => beerLifetime;
    public override NumberRange SpawnerCooldownRange => beerSpawnerCooldownRange;
}