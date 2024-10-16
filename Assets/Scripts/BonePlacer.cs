using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePlacer : MonoBehaviour
{
    public Bone bonePrefab;
    public float spawnRateAverage = 1.0f;
    public float spawnRateRange = 0.5f;

    public void Start() {
        spawnRateAverage = GameParameters.BoneSpawnerCooldownAverage;
        spawnRateRange = GameParameters.BoneSpawnerCooldownRange;
        StartCoroutine(BoneSpawner());
    }

    public void Place(Vector2 position) {
        Bone bone = Instantiate(bonePrefab, new Vector3(position.x, position.y ,1), Quaternion.identity);
    }

    private IEnumerator BoneSpawner() {
        while (true) {
            Place(SpriteTools.RandomLocationWorldSpace());
            yield return new WaitForSeconds(spawnRateAverage + Random.Range(-spawnRateRange, spawnRateRange)/2.0f);
        }
    }
}
