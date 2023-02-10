using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatsData
{
    private int number;

    private List<StatKey> statKey = new List<StatKey>();

    private List<float> minValue = new List<float>();

    private List<float> maxValue = new List<float>();

    private List<float> @value = new List<float>();

    public StatsData(List<Stat> stats)
    {
        this.number = stats.Count;
        foreach (Stat stat in stats)
        {
            this.statKey.Add(stat.statKey);
            this.minValue.Add(stat.minValue);
            this.maxValue.Add(stat.maxValue);
            this.@value.Add(stat.@value);
        }
    }

    public GameObject GetStats()
    {
        GameObject gameObject = (GameObject)Resources.Load("Prefabs/Pack", typeof(GameObject));
        GameObject gameObject1 = (GameObject)Resources.Load("Prefabs/Stats/Empty", typeof(GameObject));
        GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
        for (int i = 0; i < this.number; i++)
        {
            Stat component = Object.Instantiate<GameObject>(gameObject1, gameObject2.transform).GetComponent<Stat>();
            component.statKey = this.statKey[i];
            component.minValue = this.minValue[i];
            component.maxValue = this.maxValue[i];
            component.@value = this.@value[i];
        }
        return gameObject2;
    }
}