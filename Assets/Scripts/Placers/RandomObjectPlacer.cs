using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
    public Object objectPrefab;
    protected NumberRange spawnCooldownRange;

    public void Place(Vector2 position) {
        Object newObject = Instantiate(objectPrefab, new Vector3(position.x, position.y ,1), Quaternion.identity);
    }

    public IEnumerator ObjectSpawner() {
        while (true) {
            Place(SpriteTools.RandomLocationWorldSpace());
            yield return new WaitForSeconds(spawnCooldownRange.GetRandomNumber());
        }
    }
}
