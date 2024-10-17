using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePlacer : RandomObjectPlacer
{
    public void Start() {
        spawnCooldownRange = GameParameters.BoneSpawnerCooldownRange;
        StartCoroutine(ObjectSpawner());
    }
}
