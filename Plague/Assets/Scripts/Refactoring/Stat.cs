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
        onValueChange += ()=> value = Mathf.Clamp(value, minValue, maxValue);
    }

    public void Change(float delta)
    {
        value += delta;
        onValueChange.Invoke();
    }

    public void SetRandomValue()
    {
        value = Random.Range(minValue, maxValue);
    }
}
