using System.Collections;
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

    private bool loading = false;
    private bool randomValues = false;

    private Random rnd = new Random();

    private void Awake()
    {
        target = GetComponent<ItemContainer>();
    }

    public void Fill()
    {
        

        if (loading)
        {
            objectsToInject = savedObjectsToInject;
            randomValues = false;
            number = objectsToInject.Count;
        }
        else
        {
            objectsToInject = prefabsToInject;
            randomValues = true;
        }


        for (int i = 0; i < number; i++)
        {
            GameObject instance = 
                Instantiate(objectsToInject[rnd.Next(objectsToInject.Count)]);
            if (randomValues)
            {
                instance.GetComponentInChildren<Stat>().SetRandomValue();
            }


            target.Add(instance.GetComponent<Object>());
            instance.SetActive(false);
        }
    }
}
