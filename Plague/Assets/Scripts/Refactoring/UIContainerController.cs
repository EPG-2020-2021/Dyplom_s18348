using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIContainerController : MonoBehaviour
{

    public delegate void OnContainerUpdate();
    public OnContainerUpdate onContainerUpdateCallback;

    protected List<ItemSlot> slots;
    public ItemContainer container;

    public bool Add(Object item, int? place = null)
    {
        var slot = GetFreeSlot(place);
        if (slot)
        {
            slot.item = item;
            onContainerUpdateCallback?.Invoke();
            return true;
        }
        else
        {
            return false;
        }

    }

    public void Remove(Object item)
    {
        print(item?.name + "item");
        container.Remove(item);
    }

    private ItemSlot GetFreeSlot(int? number = null)
    {
        int counter = 0;

        foreach (var slot in slots)
        {
            if (number != null && counter.Equals(number) && !slot.item )
            {
                return slot;
            }
            if (number is null && !slot.item )
            {
                return slot;
            }
            counter++;
        }

        return null;
    }

    public int GetSize()
    {
        Init();
        return slots.Count;
    }

    public virtual void Init()
    {
        if (slots != null)
        {
            slots = new List<ItemSlot>();
        }


        slots = GetComponentsInChildren<ItemSlot>().ToList();
        

        foreach (var slot in slots)
        {
            slot.Init();
        }

        //container = PlayerScript.instance.inventory;


    }

    public void RemoveAll()
    {
        foreach (var slot in slots)
        {
            slot.Remove();
        }
    }

}