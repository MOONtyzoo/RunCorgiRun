using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRange
{
    public float minNumber;
    public float maxNumber;

    public NumberRange(float minNumber, float maxNumber) {
        this.minNumber = minNumber;
        this.maxNumber = maxNumber;
    }

    public float GetRandomNumber() {
        return Random.Range(minNumber, maxNumber);
    }
}
