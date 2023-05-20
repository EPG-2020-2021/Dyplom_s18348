using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIContainerController : MonoBehaviour
{
    public UIContainerController.OnContainerUpdate onContainerUpdateCallback;

    protected List<ItemSlot> slots;

    public ItemContainer container;

    public UIContainerController()
    {
    }

    public bool Add(Object item, int? place = null)
    {
        ItemSlot freeSlot = this.GetFreeSlot(place);
        if (!freeSlot)
        {
            return false;
        }
        freeSlot.item = item;
        UIContainerController.OnContainerUpdate onContainerUpdate = this.onContainerUpdateCallback;
        if (onContainerUpdate != null)
        {
            onContainerUpdate();
        }
        else
        {
        }
        return true;
    }

    public ItemSlot GetSlotWithItem(Object item)
    {
        return slots.Find(x => x.item.Equals(item));
    }

    private ItemSlot GetFreeSlot(int? number = null)
    {
        ItemSlot itemSlot;
        int num = 0;
        List<ItemSlot>.Enumerator enumerator = this.slots.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                ItemSlot current = enumerator.Current;
                if (number.HasValue && num.Equals(number) && !current.item)
                {
                    itemSlot = current;
                    return itemSlot;
                }
                else if (number.HasValue || current.item)
                {
                    num++;
                }
                else
                {
                    itemSlot = current;
                    return itemSlot;
                }
            }
            return null;
        }
        finally
        {
            ((IDisposable)enumerator).Dispose();
        }
        return itemSlot;
    }

    public int GetSize()
    {
        this.Init();
        return this.slots.Count;
    }

    public virtual void Init()
    {
        if (this.slots != null)
        {
            this.slots = new List<ItemSlot>();
        }
        this.slots = base.GetComponentsInChildren<ItemSlot>().ToList<ItemSlot>();
        foreach (ItemSlot slot in this.slots)
        {
            slot.Init();
        }
    }

    public void Remove(Object item)
    {
        this.container.Remove(item);
    }

    public void RemoveAll()
    {
        foreach (ItemSlot slot in this.slots)
        {
            slot.Remove();
        }
    }

    public delegate void OnContainerUpdate();
}