using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    protected int inventorySize = 0;
    public List<Object> container = new List<Object>();

    public UIContainerController containerController;

    public ContainerFiller containerFiller;


    private void Start()
    {

    }
    public virtual void Add(Object item, int? place = null)
    {
        print("Added " + item.name);
        if (!EnoughSpace())
        {
            print("Not enough space");
            return;
        }


        container.Add(item);
        containerController.Add(item, place);

        if (gameObject.CompareTag("Player"))
        {
            SaveSystem.SaveContainer(this);
        }
    }

    internal virtual void Remove(Object item)
    {
        container.Remove(item);
        if (gameObject.CompareTag("Player"))
        {
            SaveSystem.SaveContainer(this);
        }
    }

    public virtual bool Has(Object item)
    {
        if (container.Contains(item))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private bool EnoughSpace()
    {
        return container.Count < inventorySize ? true : false;
    }

    public void RemoveAll()
    {
        containerController.RemoveAll();
    }
}
