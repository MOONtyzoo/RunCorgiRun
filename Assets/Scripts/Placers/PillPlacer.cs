using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillPlacer : RandomObjectPlacer
{
    public void Start() {
        spawnCooldownRange = GameParameters.PillSpawnerCooldownRange;
        StartCoroutine(ObjectSpawner());
    }
}
