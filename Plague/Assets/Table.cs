using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Table : ItemContainer, IGivable
{
    private string statsPath = "Prefabs/Stats/Empty";

    private string streptomycinPath = "Prefabs/Items/Plants/Streptomycin";

    public GameObject resultPrefab;

    private List<Stat> resultStats = new List<Stat>();

    public GameObject resultObject;

    private GameObject streptomycinPrefab;

    public Table()
    {
    }

    public Stat AddStat(StatKey name, float value)
    {
        GameObject gameObject = (GameObject)Resources.Load(this.statsPath, typeof(GameObject));
        Stat component = this.resultObject.GetComponentsInChildren<Stat>().ToList<Stat>().Find((Stat curStat) => curStat.statKey.Equals(name));
        if (!component)
        {
            component = Object.Instantiate<GameObject>(gameObject, this.resultObject.transform.Find("Stats").transform).GetComponent<Stat>();
            component.@value = value;
            component.statKey = name;
        }
        else
        {
            MonoBehaviour.print(component.name);
            component.@value += value;
        }
        return component;
    }

    public void Craft()
    {
        bool flag = true;
        if (this.container.Count == 3 && PlayerScript.instance.playerStats.GetStat(StatKey.Decription).@value.Equals(100f))
        {
            foreach (Object obj in this.container)
            {
                if (obj.name.Equals("Soil"))
                {
                    continue;
                }
                flag = false;
            }
            if (flag)
            {
                base.RemoveAll();
                this.resultObject = Object.Instantiate<GameObject>(this.streptomycinPrefab);
                this.Add(this.resultObject.GetComponent<Object>(), new int?(this.inventorySize - 1));
                return;
            }
        }
        if (this.resultObject && !this.container.Contains(this.resultObject.GetComponent<Object>()))
        {
            this.resultObject = null;
        }
        if (this.container.Count <= 1 || this.container.Count >= 4 || this.resultObject)
        {
            return;
        }
        float count = 0f;
        foreach (Object obj1 in this.container)
        {
            List<Stat> list = obj1.GetComponentsInChildren<Stat>().ToList<Stat>();
            Stat stat1 = list.Find((Stat stat) => stat.statKey.Equals(StatKey.Quality));
            float single = stat1.@value;
            list.Remove(stat1);
            this.resultStats.AddRange(this.GetRandomStats(list, single));
            count = count + single / (float)this.container.Count;
        }
        if (this.resultStats == null)
        {
            return;
        }
        this.resultObject = Object.Instantiate<GameObject>(this.resultPrefab);
        this.resultObject.GetComponentInChildren<Stat>().@value = count;
        foreach (Stat resultStat in this.resultStats)
        {
            this.AddStat(resultStat.statKey, resultStat.@value);
        }
        base.RemoveAll();
        this.Add(this.resultObject.GetComponent<Object>(), new int?(this.inventorySize - 1));
    }

    private List<Stat> GetRandomStats(List<Stat> stats, float quality)
    {
        int count = (int)((float)stats.Count * quality / 100f);
        List<Stat> stats1 = new List<Stat>();
        while (stats1.Count < count)
        {
            int num = UnityEngine.Random.Range(0, stats.Count);
            stats1.Add(stats[num]);
            stats.RemoveAt(num);
        }
        return stats1;
    }

    public void PutObject(Object obj)
    {
        this.Add(obj, null);
    }

    private void Start()
    {
        this.containerController = UIManager.instance.craftUi;
        this.containerController.Init();
        this.inventorySize = this.containerController.GetSize();
        this.streptomycinPrefab = (GameObject)Resources.Load(this.streptomycinPath, typeof(GameObject));
    }
}