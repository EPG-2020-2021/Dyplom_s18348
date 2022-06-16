using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Table : ItemContainer, IGivable
{
    private string statsPath = "Prefabs/Stats/Empty";

    //public List<GameObject> container;

    public GameObject resultPrefab;
    private List<Stat> resultStats = new List<Stat>();

    public GameObject resultObject;


    private void Start()
    {
        containerController = UIManager.instance.craftUi;

        containerController.Init();
        inventorySize = containerController.GetSize();
    }


    public void Craft()
    {
        if (container.Count <= 1 || container.Count >= 4 || resultObject)
        {
            return;
        }

        float avgResultQuality = .0f;

        foreach (var obj in container)
        {
            var stats = obj.GetComponentsInChildren<Stat>().ToList();
            var qualityStat = stats.Find(stat => stat.statKey.Equals(StatKey.Quality));
            var quality = qualityStat.value;
            stats.Remove(qualityStat);
            resultStats.AddRange(GetRandomStats(stats, quality));
            avgResultQuality += quality/container.Count;    
        }

        if (resultStats is null)
        {
            return;
        }



        resultObject = Instantiate(resultPrefab);
        resultObject.GetComponentInChildren<Stat>().value = avgResultQuality;

        foreach (var stat in resultStats)
        {
            AddStat(stat.statKey, stat.value);
        }

        RemoveAll();
        Add(resultObject.GetComponent<Object>(), inventorySize - 1);
    }

    private List<Stat> GetRandomStats(List<Stat> stats, float quality){
        int number = (int)(stats.Count * quality / 100f);

        var randomStats = new List<Stat>();
        while (randomStats.Count < number) //random bool
        {
            var randInt = Random.Range(0, stats.Count);
            randomStats.Add(stats[randInt]);
            stats.RemoveAt(randInt);
        }


        return randomStats;
    }

    public Stat AddStat(StatKey name, float value)
    {
        var statPrefab = (GameObject)Resources.Load(statsPath, typeof(GameObject));
        var stat = resultObject.GetComponentsInChildren<Stat>().ToList().Find(curStat => curStat.statKey.Equals(name));
        if (stat)
        {
            print(stat.name)
;            stat.value += value;
        }
        else
        {
            stat = Instantiate(statPrefab, resultObject.transform.Find("Stats").transform).GetComponent<Stat>();
            stat.value = value;
            stat.statKey = name;
            
        }
        return stat;
    }

    public void PutObject(Object obj)
    {
        Add(obj);
    }
}
