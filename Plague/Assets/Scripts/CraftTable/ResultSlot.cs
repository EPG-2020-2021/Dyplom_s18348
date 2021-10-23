using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSlot : MonoBehaviour
{
    public Image icon;
    //public Button removeButton;

    public Item item;
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon.sprite;
        icon.enabled = true;
        transform.GetComponentInChildren<Button>().interactable = true;

        //removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        Inventory.instance.Add(item);

        CraftTable.instance.resultItem = null;

        item = null;

        icon.sprite = null;
        icon.enabled = false;

        //removeButton.interactable = false;


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
