using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    public StatKey statKey { get; private set; }

    [SerializeField]
    private float maxValue, minValue;

    public float value;
    public void Increase(float increaser)
    {
        value += increaser;
        value = Mathf.Clamp(value, minValue, maxValue);
    }

    public void Decrease(float decreaser)
    {
        value -= decreaser;
        value = Mathf.Clamp(value, minValue, maxValue);
    }

}
