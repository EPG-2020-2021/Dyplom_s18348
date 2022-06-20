using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private List<Stat> stats;
    private string statsPath = "Prefabs/Stats/";
    public TextMeshProUGUI statsText;
    private void Awake()
    {
        stats = new List<Stat>(GetComponentsInChildren<Stat>());
        SaveSystem.LoadStats(this);
        UpdateStatsText();
    }

    private void Start()
    {

        UpdateStatsText();
    }
    public Stat GetStat(StatKey key)
    {
        Stat stat = stats.Find(item => item.statKey.Equals(key));

        if (stat == null)
        {
            
            stat = AddStat(key);
        }

        UpdateStatsText();
        return stat;
    }

    public List<Stat> GetStats()
    {
        return stats;
    }
    public void SetStats(List<Stat> newStats)
    {
        UpdateStatsText();
        stats = newStats;
    }

    public Stat AddStat(StatKey name)
    {
        if (name.Equals(StatKey.Quality))
        {
            return null;
        }
        Debug.Log(name);
        var statPrefab = (GameObject)Resources.Load(statsPath + name.ToString(), typeof(GameObject));
        //
        /*//
        var stat = Instantiate(statPrefab, transform.Find("Stats").transform).GetComponent<Stat>();
        stat.value = value;
        stat.statKey = name;
        *///
        //
        var stat = Instantiate(statPrefab, transform.Find("Stats").transform).GetComponent<Stat>();
        stat.SetRandomValue();
        stats.Add(stat);
        UpdateStatsText();
        return stat;
    }

    public string GetStatsString()
    {
        var stringResult = "";
        foreach (var stat in stats)
        {
            stringResult += $"- {stat.statKey.ToString()}: {stat.value}\n";
        }
        return stringResult;
    }

    public void UpdateStatsText()
    {
        SaveSystem.SaveStats(this);
        statsText.text = GetStatsString();
        if (gameObject.CompareTag("Player"))
        {
            //statsText.text += "Money: " + PlayerScript.instance.moneyController.GetMoneyAmount();
        }
    }
}
