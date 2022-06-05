using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerFiller : MonoBehaviour
{
    public List<GameObject> objectsToInject;
    public List<GameObject> prefabsToInject;
    private List<GameObject> savedObjectsToInject;
    private ItemContainer target;

    public bool loading = false;
    public bool randomValues = false; 

    private void Awake()
    {
        target = GetComponent<ItemContainer>();
    }

    public void Fill()
    {
        

        if (loading)
        {
            objectsToInject = savedObjectsToInject;
        }
        else
        {
            objectsToInject = prefabsToInject;
        }


        foreach (var obj in objectsToInject)
        {
            GameObject instance = Instantiate(obj);
            
            if (randomValues)
            {
                instance.GetComponentInChildren<Stat>().SetRandomValue();
            }


            target.Add(instance.GetComponent<Object>());
            instance.SetActive(false);
        }
    }
}
