using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoonshinePlacer : RandomObjectPlacer
{
    float cooldownMultiplier = 1.0f;

    public void Start() {
        spawnCooldownRange = GameParameters.MoonshineSpawnerCooldownRange;
        StartCoroutine(ObjectSpawner());
    }

    public override IEnumerator ObjectSpawner() {
        while (true) {
            Place(SpriteTools.RandomTopOfScreenLocationWorldSpace());
            UpdateCooldownMultiplier();

            float spawnCooldown = cooldownMultiplier*spawnCooldownRange.GetRandomNumber();
            yield return new WaitForSeconds(spawnCooldown);
        }
    }

    public void UpdateCooldownMultiplier() {
        float timerProgress = Game.Instance.GetTimerProgressPercentage();
        cooldownMultiplier = (1-timerProgress)*1.0f + timerProgress*GameParameters.MoonshineCooldownMultiplierAtGameEnd;
    }
}
