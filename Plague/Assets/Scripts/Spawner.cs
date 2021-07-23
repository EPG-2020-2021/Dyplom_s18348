using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    public CraftItem prefabToSpawn;
    public string nameofspawnitem;


    public int max = 0;
    public int delaymin = 0, delaymax = 0;
    
    List<Item> items;
    
    int x, y;

    float lastSpawn = 0f;

    bool spawnOnlyTillDay = false;

    static Random rnd = new Random();

    Vector3 size;

    void Start()
    {
        prefabToSpawn = Resources.Load<CraftItem>("Prefabs/Craft Item");
        items = new List<Item>();
        size = GetComponent<SpriteRenderer>().bounds.size;
    }

    void Update()
    {
        if (Time.time - lastSpawn > delaymin &&
            items.Count < max && // if enough space
            Time.time - lastSpawn > rnd.Next(delaymin, delaymax))
        {
            x = rnd.Next(-(int)size.x / 2, (int)size.x / 2);
            y = rnd.Next(-(int)size.y / 2, (int)size.y / 2);

            
            CraftItem item = Instantiate(prefabToSpawn, transform, false);
            item.ItemName = nameofspawnitem;
            item.transform.localPosition = new Vector3(x, y, 0);
            items.Add(item);

            lastSpawn = Time.time;
        }
        cleaner();
    }

    void cleaner()
    {
        foreach (var ci in items)
        {
            if (!ci.gameObject.activeSelf)
            {
                items.Remove(ci);
            }
        }
    }
}
