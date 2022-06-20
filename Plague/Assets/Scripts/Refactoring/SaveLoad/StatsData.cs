using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsData
{
    private int number;

    private List<StatKey> statKey = new List<StatKey>();

    private List<float> minValue = new List<float>(), maxValue = new List<float>();

    private List<float> value = new List<float>();

    public StatsData (List<Stat> stats)
    {
        number = stats.Count;

        foreach (var stat in stats)
        {
            statKey.Add(stat.statKey);
            minValue.Add(stat.minValue);
            maxValue.Add(stat.maxValue);
            value.Add(stat.value);
        }

    }

    public GameObject GetStats()
    {
        var statPackPrefab = (GameObject)Resources.Load("Prefabs/Pack", typeof(GameObject));
        var statPrefab = (GameObject)Resources.Load("Prefabs/Stats/Empty", typeof(GameObject));
        var statPack = GameObject.Instantiate(statPackPrefab);




        for (int i = 0; i < number; i++)
        {
            var stat = GameObject.Instantiate(statPrefab, statPack.transform).GetComponent<Stat>();

            stat.statKey = statKey[i];
            stat.minValue = minValue[i];
            stat.maxValue = maxValue[i];
            stat.value = value[i];
        }

        return statPack;
    }

}
