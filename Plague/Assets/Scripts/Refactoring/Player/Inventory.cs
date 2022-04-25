using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int inventorySize = 0;
    private List<Object> inventory = new List<Object>();

    private UIInventoryController inventoryController;


    private void Start()
    {
        inventoryController = UIManager.instance.inventoryController;
        inventoryController.Init();
        inventorySize = inventoryController.GetSize();
    }

    public void Add(Object item)
    {
        if (!EnoughSpace())
        {
            print("Not enough space");
            return;
        }


        inventory.Add(item);
        inventoryController.Add(item);
    }

    internal void Remove(Object item)
    {
        inventory.Remove(item);
    }

    public bool Has (Object item)
    {
        if (inventory.Contains(item))
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
        return inventory.Count < inventorySize ? true : false;
    }
}
