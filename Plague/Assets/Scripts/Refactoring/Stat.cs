using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    public StatKey statKey;

    [SerializeField]
    private float minValue = 0, maxValue = 10;

    [SerializeField]
    public float value = 0;

    public delegate void OnValueChange();
    public OnValueChange onValueChange;
    private void Awake()
    {
        value = Mathf.Clamp(value, minValue, maxValue);
    }

    public void Increase(float increaser)
    {
        value += increaser;
        value = Mathf.Clamp(value, minValue, maxValue);

        onValueChange.Invoke();
    }

    public void Decrease(float decreaser)
    {
        value -= decreaser;
        value = Mathf.Clamp(value, minValue, maxValue);

        onValueChange.Invoke();
    }



}
