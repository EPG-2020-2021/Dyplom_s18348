using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIContainerController : MonoBehaviour
{

    public delegate void OnContainerUpdate();
    public OnContainerUpdate onContainerUpdateCallback;

    protected List<ItemSlot> slots;
    public ItemContainer container;

    public void Add(Object item)
    {
        GetFreeSlot().item = item;
        onContainerUpdateCallback?.Invoke();
    }

    public void Remove(Object item)
    {
        print(item?.name + "item");
        container.Remove(item);
    }

    private ItemSlot GetFreeSlot()
    {
        foreach (var slot in slots)
        {
            if (!slot.item)
            {
                return slot;
            }
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

}