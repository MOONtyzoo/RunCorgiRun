using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    public Poop poopPrefab;

    public void Place(Vector2 position) {
        Poop poop = Instantiate(poopPrefab, new Vector3(position.x, position.y ,1), Quaternion.identity);
    }
}
