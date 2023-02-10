using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ContainerFiller : MonoBehaviour
{
    public List<GameObject> objectsToInject;

    public List<GameObject> prefabsToInject;

    private List<GameObject> savedObjectsToInject;

    private ItemContainer target;

    public int number;

    private bool loading;

    private bool randomValues;

    private Random rnd = new Random();

    public ContainerFiller()
    {
    }

    private void Awake()
    {
        this.target = base.GetComponent<ItemContainer>();
    }

    public void Fill()
    {
        GameObject gameObject;
        if (!this.loading)
        {
            this.objectsToInject = this.prefabsToInject;
            this.randomValues = true;
        }
        else
        {
            this.objectsToInject = this.savedObjectsToInject;
            this.randomValues = false;
            this.number = this.objectsToInject.Count;
        }
        for (int i = 0; i < this.number; i++)
        {
            gameObject = (!this.loading ? Object.Instantiate<GameObject>(this.objectsToInject[this.rnd.Next(this.objectsToInject.Count)]) : Object.Instantiate<GameObject>(this.objectsToInject[i]));
            if (this.randomValues)
            {
                StatsApplier.RandomiseStats(gameObject);
            }
            this.target.Add(gameObject.GetComponent<Object>(), null);
            gameObject.SetActive(false);
        }
    }

    public void Load(List<GameObject> objs)
    {
        this.target.RemoveAll();
        this.savedObjectsToInject = objs;
        this.loading = true;
        this.Fill();
        this.loading = false;
    }
}