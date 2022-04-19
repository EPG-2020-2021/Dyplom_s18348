using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    public Image icon;
    //public Button removeButton;

    public Item item;

    public void AddItem(Item newItem)
    {
        print(newItem.ItemName);
        //CraftTable.instance.Add(newItem);
        item = newItem;
        icon.sprite = item.icon.sprite;
        icon.enabled = true;

        //removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        if (CraftTable.instance.items.Count != 0)
        {
            InventoryOLD.instance.Add(item);
        }
        

        CraftTable.instance.Remove((CraftItem)item);

        item = null;

        icon.sprite = null;
        icon.enabled = false;

        //removeButton.interactable = false;
    }

    public void DeleteSlots()
    {

    }
        
    //public void OnRemoveButton()
    //{
    //    Inventory.instance.Remove(item);
    //}

    public void OnItemButton()
    {
               
        
        ClearSlot();
       
    }
}
