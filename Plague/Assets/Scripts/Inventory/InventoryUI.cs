using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemParent;


    InventorySlot[] slots;

    Inventory inventory;
    GameObject UIInventory;

    // Start is called before the first frame update

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIInventory.SetActive(!UIInventory.activeSelf);
        }
    }
    void Start()
    {
        UIInventory = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;


        slots = itemParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count) { 
            slots[i].AddItem(inventory.items[i]);
        }else
            {
            slots[i].ClearSlot();
            }
        }
    }
}
