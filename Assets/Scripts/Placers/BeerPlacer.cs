using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPlacer : RandomObjectPlacer
{
    public void Start()
    {
        spawnCooldownRange = scriptableObject.SpawnerCooldownRange;
        StartCoroutine(ObjectSpawner());
    }
}
