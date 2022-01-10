using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private List<Stat> stats;

    private void Awake()
    {
        stats = new List<Stat>(GetComponentsInChildren<Stat>());
    }

    public Stat GetStat(StatKey key)
    {
        Stat stat = stats.Find(item => item.statKey.Equals(key));

        if (stat == null)
        {
            AddStat(key);
            stat = stats.Find(item => item.statKey.Equals(key));
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

    public void AddStat(StatKey name)
    {
        var stat = (GameObject)Resources.Load("Prefabs/Stats/" + name.ToString(), typeof(GameObject));
        //print("../Prefabs/Stats/" + name.ToString());
        stats.Add(Instantiate(stat, transform.Find("Stats").transform).GetComponent<Stat>());
        
    }
}
