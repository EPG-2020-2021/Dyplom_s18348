using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private List<Stat> stats;

    private string statsPath = "Prefabs/Stats/";

    public TextMeshProUGUI statsText;

    public CharacterStats()
    {
    }

    public Stat AddStat(StatKey name)
    {
        if (name.Equals(StatKey.Quality))
        {
            return null;
        }
        Debug.Log(name);
        Stat component = Object.Instantiate<GameObject>((GameObject)Resources.Load(String.Concat(this.statsPath, name.ToString()), typeof(GameObject)), base.transform.Find("Stats").transform).GetComponent<Stat>();
        component.SetRandomValue();
        this.stats.Add(component);
        this.UpdateStatsText();
        return component;
    }

    private void Awake()
    {
        this.stats = new List<Stat>(base.GetComponentsInChildren<Stat>());
        SaveSystem.LoadStats(this);
        this.UpdateStatsText();
    }

    public bool Cured()
    {
        bool flag;
        List<Stat>.Enumerator enumerator = this.stats.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Stat current = enumerator.Current;
                if (current.statKey.Equals(StatKey.Health) || current.statKey.Equals(StatKey.Speed) || current.statKey.Equals(StatKey.Decription) || current.statKey.Equals(StatKey.Quality) || current.@value <= 0f)
                {
                    continue;
                }
                flag = false;
                return flag;
            }
            return true;
        }
        finally
        {
            ((IDisposable)enumerator).Dispose();
        }
        return flag;
    }

    public Stat GetStat(StatKey key)
    {
        Stat stat = this.stats.Find((Stat item) => item.statKey.Equals(key));
        if (stat == null)
        {
            stat = this.AddStat(key);
        }
        this.UpdateStatsText();
        return stat;
    }

    public List<Stat> GetStats()
    {
        return this.stats;
    }

    public string GetStatsString()
    {
        string str = "";
        foreach (Stat stat in this.stats)
        {
            str = String.Concat(str, String.Format("- {0}: {1}\n", (object)stat.statKey.ToString(), stat.@value));
        }
        return str;
    }

    public void SetStats(List<Stat> newStats)
    {
        this.UpdateStatsText();
        this.stats = newStats;
    }

    private void Start()
    {
        this.UpdateStatsText();
    }

    public void UpdateStatsText()
    {
        SaveSystem.SaveStats(this);
        this.statsText.text = this.GetStatsString();
    }
}