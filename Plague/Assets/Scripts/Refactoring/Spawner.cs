using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public int max = 0;
    public int delaymin = 0, delaymax = 0;
    
    public List<GameObject> items;

    private float x, y;

    private float lastSpawn = 0f;

    //public bool spawnOnlyTillDay = false;

    private static Random rnd = new Random();

    private Vector3 size;

    void Start()
    {
        items = new List<GameObject>();
        size = GetComponent<SpriteRenderer>().bounds.size;
    }

    void FixedUpdate()
    {
        if (Time.time - lastSpawn > delaymin &&
            items.Count < max && // if enough space
            Time.time - lastSpawn > Random.Range(delaymin, delaymax))
        {
            x = Random.Range(-size.x / 2f, size.x / 2f);
            y = Random.Range(-size.y / 2f, size.y / 2f);

            
            var item = Instantiate(prefabToSpawn, transform, false);
            StatsApplier.RandomiseStats(item);
            item.transform.localPosition = new Vector3(x, y, -0.05f);
            items.Add(item);

            lastSpawn = Time.time;
        }
        Cleaner();
    }

    

    void Cleaner()
    {
        foreach (var obj in items)
        {
            if (!obj.gameObject.activeSelf)
            {
                items.Remove(obj);
                return;
            }
        }
    }
}
