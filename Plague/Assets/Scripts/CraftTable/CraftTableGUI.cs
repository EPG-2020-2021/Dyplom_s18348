using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTableGUI : MonoBehaviour
{

    bool interactible = false;
    public GameObject player;

    GameObject CTgui;
    CraftSlot[] slots;

    public Transform itemParent;
    CraftTable inventory;

    public bool CraftTableOpend = false;
    // Start is called before the first frame update
    void Start()
    {
        CTgui = GameObject.Find("Canvas").transform.Find("CraftTableInventory").gameObject;
        itemParent = CTgui.transform.GetChild(0);
        slots = itemParent.GetComponentsInChildren<CraftSlot>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            interactible = true;
            CraftTable.instance = gameObject.GetComponent<CraftTable>();
            inventory = CraftTable.instance;
            inventory.onItemAddCallback += AddUI;
            inventory.onItemRemoveCallback += RemoveUI;
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            interactible = false;
            CTgui.SetActive(false);
            CraftTableOpend = false;
            Inventory.instance.craftTable = gameObject;
        }
    }

    void UpdateUI()
    {
       
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    void AddUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<CraftSlot>().item == null)
            {
                slots[i].AddItem(inventory.items[inventory.items.Count - 1]);
                return;
            }
        }
         
    }

    void RemoveUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!inventory.items.Contains((CraftItem)slots[i].GetComponent<CraftSlot>().item))
            {
                slots[i].ClearSlot();
                return;
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactible)
        {

            if (CraftTableOpend)
            {
                CTgui.SetActive(false);
                CraftTableOpend = false;
                return;
            }
            Debug.Log("Interaction with CraftTable");
            CTgui.SetActive(true);
            CraftTableOpend = true;
            


        }
        
    }
}
