using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    protected int inventorySize;

    public List<Object> container = new List<Object>();

    public UIContainerController containerController;

    public ContainerFiller containerFiller;

    public delegate void OnNewItem(Object item);
    public OnNewItem onNewItemCallback;

    public ItemContainer()
    {
    }

    public virtual void Add(Object item, int? place = null)
    {
        if (!this.EnoughSpace())
        {
            MonoBehaviour.print("Not enough space");
            return;
        }
        this.container.Add(item);
        this.containerController.Add(item, place);
        print(String.Concat("Added ", item.name));
        onNewItemCallback?.Invoke(item);
        if (base.gameObject.CompareTag("Player"))
        {
            SaveSystem.SaveContainer(this);
        }
    }

    private bool EnoughSpace()
    {
        if (this.container.Count >= this.inventorySize)
        {
            return false;
        }
        return true;
    }

    public virtual bool Has(Object item)
    {
        if (this.container.Contains(item))
        {
            return true;
        }
        return false;
    }

    internal virtual void Remove(Object item)
    {
        this.container.Remove(item);
        if (base.gameObject.CompareTag("Player"))
        {
            SaveSystem.SaveContainer(this);
        }
    }

    public void RemoveAll()
    {
        this.containerController.RemoveAll();
    }

    private void Start()
    {
    }
}