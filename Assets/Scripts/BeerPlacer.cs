using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPlacer : MonoBehaviour
{
    public Beer beerPrefab;

    public void Start() {

    }

    public void Place(Vector2 position) {
        Beer beer = Instantiate(beerPrefab, new Vector3(position.x, position.y ,1), Quaternion.identity);
    }
}
