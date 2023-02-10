using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public int max;

    public int delaymin;

    public int delaymax;

    public List<GameObject> items;

    private float x;

    private float y;

    private float lastSpawn;

    private static Random rnd;

    private Vector3 size;

    static Spawner()
    {
        Spawner.rnd = new Random();
    }

    public Spawner()
    {
    }

    private void Cleaner()
    {
        foreach (GameObject item in this.items)
        {
            if (item.gameObject.activeSelf)
            {
                continue;
            }
            this.items.Remove(item);
            return;
        }
    }

    private void FixedUpdate()
    {
        if (Time.time - this.lastSpawn > (float)this.delaymin && this.items.Count < this.max && Time.time - this.lastSpawn > (float)Random.Range(this.delaymin, this.delaymax))
        {
            this.x = Random.Range(-this.size.x / 2f, this.size.x / 2f);
            this.y = Random.Range(-this.size.y / 2f, this.size.y / 2f);
            GameObject vector3 = Object.Instantiate<GameObject>(this.prefabToSpawn, base.transform, false);
            StatsApplier.RandomiseStats(vector3);
            vector3.transform.localPosition = new Vector3(this.x, this.y, -0.05f);
            this.items.Add(vector3);
            this.lastSpawn = Time.time;
        }
        this.Cleaner();
    }

    private void Start()
    {
        this.items = new List<GameObject>();
        this.size = base.GetComponent<SpriteRenderer>().bounds.size;
    }
}