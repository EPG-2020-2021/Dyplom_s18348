using System;
using System.Runtime.CompilerServices;
using UnityEngine;

using Random = UnityEngine.Random;
public class Stat : MonoBehaviour
{
    [SerializeField]
    public StatKey statKey;

    [SerializeField]
    public float minValue;

    [SerializeField]
    public float maxValue = 10f;

    [SerializeField]
    public float @value;

    public Stat.OnValueChange onValueChange;

    public Stat()
    {
    }

    private void Awake()
    {
        this.onValueChange += new Stat.OnValueChange(() => this.@value = Mathf.Clamp(this.@value, this.minValue, this.maxValue));
    }

    public void Change(float delta)
    {
        this.@value += delta;
        Stat.OnValueChange onValueChange = this.onValueChange;
        if (onValueChange == null)
        {
            return;
        }
        onValueChange();
    }

    public void Set(float value)
    {
        this.@value = value;
        Stat.OnValueChange onValueChange = this.onValueChange;
        if (onValueChange == null)
        {
            return;
        }
        onValueChange();
    }

    public void SetRandomValue()
    {
        this.@value = Random.Range(this.minValue, this.maxValue);
        if (this.statKey.Equals(StatKey.Plague))
        {
            this.@value = (this.@value < 0f ? 0f : this.@value);
        }
    }

    public delegate void OnValueChange();
}