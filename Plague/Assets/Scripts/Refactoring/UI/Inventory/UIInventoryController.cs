using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    
    public delegate void OnInventoryUpdate();
    public OnInventoryUpdate onInventoryUpdateCallback;

    private List<ItemSlot> slots;
    private Inventory inventory;

    public void OpenClose()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void Add(Object item)
    {
        GetFreeSlot().item = item;
        onInventoryUpdateCallback?.Invoke();
    }

    public void Remove(Object item)
    {
        inventory.Remove(item);
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

    public void Init()
    {
        if (slots != null)
        {
            return;           
        }


        slots = GetComponentsInChildren<ItemSlot>().ToList();
        inventory = PlayerScript.instance.inventory;

        foreach (var slot in slots)
        {
            slot.Init();
        }

    }

    private void Start()
    {
        Init();
    }

}
