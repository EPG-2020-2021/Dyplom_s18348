using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private List<Stat> stats;
    private string statsPath = "Prefabs/Stats/";
    private void Awake()
    {
        stats = new List<Stat>(GetComponentsInChildren<Stat>());
    }

    public Stat GetStat(StatKey key)
    {
        Stat stat = stats.Find(item => item.statKey.Equals(key));

        if (stat == null)
        {
            
            stat = AddStat(key);
        }

        return stat;
    }

    public List<Stat> GetStats()
    {
        return stats;
    }
    public void SetStats(List<Stat> newStats)
    {
        stats = newStats;
    }

    public Stat AddStat(StatKey name)
    {
        var statPrefab = (GameObject)Resources.Load(statsPath + name.ToString(), typeof(GameObject));
        var stat = Instantiate(statPrefab, transform.Find("Stats").transform).GetComponent<Stat>();
        stat.SetRandomValue();
        stats.Add(stat);
        return stat;
    }
}
