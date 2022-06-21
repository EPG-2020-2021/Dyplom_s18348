
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ContainerData
{
    private int size = 0;
    private List<string> name = new List<string>();
    private List<int> cost = new List<int>();

    private List<List<StatKey>> key = new List<List<StatKey>>();
    private List<List<float>> value = new List<List<float>>();


    public ContainerData(ItemContainer container)
    {
        var counter = 0;
        this.size = container.container.Count;

        foreach (var item in container.container)
        {
            this.name.Add(item.name);
            this.cost.Add(item.cost);

            this.key.Add(new List<StatKey>());
            this.value.Add(new List<float>());

            var stats = item.GetComponentsInChildren<Stat>().ToList();
            foreach (var stat in stats)
            {
                this.key[counter].Add(stat.statKey);
                this.value[counter].Add(stat.value);
            }

            counter++;
        }
    }

    public List<GameObject> GetObjects()
    {
        var containerPackPrefab = (GameObject)Resources.Load("Prefabs/Pack", typeof(GameObject));
        var objectPrefab = (GameObject)Resources.Load("Prefabs/Items/ResultObjectPrefab", typeof(GameObject));
        var containerPack = GameObject.Instantiate(containerPackPrefab);

        List<GameObject> resultList = new List<GameObject>();


        for (int i = 0; i < size; i++)
        {
            Debug.Log($"{name[i]}");
            var prefab = Resources.Load($"Prefabs/Items/Plants/{name[i]}");
            var obj = GameObject.Instantiate(objectPrefab, containerPack.transform);

            if (prefab) obj = GameObject.Instantiate(prefab, containerPack.transform) as GameObject;

            for (int j = 0; j < key[i].Count; j++)
            {
                AddStat(obj, key[i][j], value[i][j]);
            }
            obj.GetComponent<Object>().cost = cost[i];
            resultList.Add(obj);
            
        }

        return resultList;
    }

    public void AddStat(GameObject resultObject, StatKey name, float value)
    {
        var statPrefab = (GameObject)Resources.Load("Prefabs/Stats/Empty", typeof(GameObject));
        var stat = resultObject.GetComponentsInChildren<Stat>().ToList().Find(curStat => curStat.statKey.Equals(name));
        if (stat)
        {
            stat.value = value;
        }
        else
        {
            stat = GameObject.Instantiate(statPrefab, resultObject.transform).GetComponent<Stat>();
            stat.value = value;
            stat.statKey = name;
        }
    }
}
