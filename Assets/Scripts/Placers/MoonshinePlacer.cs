using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonshinePlacer : RandomObjectPlacer
{
    public void Start() {
        spawnCooldownRange = GameParameters.MoonshineSpawnerCooldownRange;
        StartCoroutine(ObjectSpawner());
    }

    public override IEnumerator ObjectSpawner() {
        while (true) {
            Place(SpriteTools.RandomTopOfScreenLocationWorldSpace());
            yield return new WaitForSeconds(spawnCooldownRange.GetRandomNumber());
        }
    }
}
