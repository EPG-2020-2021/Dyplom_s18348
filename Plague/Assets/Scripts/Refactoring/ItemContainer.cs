﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    protected int inventorySize = 0;
    public List<Object> container = new List<Object>();

    public UIContainerController containerController;

    public virtual void Add(Object item)
    {
        if (!EnoughSpace())
        {
            print("Not enough space");
            return;
        }


        container.Add(item);
        containerController.Add(item);
    }

    internal virtual void Remove(Object item)
    {
        container.Remove(item);
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

}
