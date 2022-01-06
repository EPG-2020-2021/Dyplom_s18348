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
        return stats.Find(item => item.statKey.Equals(key));
    }
}
