using System.Collections.Generic;
using UnityEngine;

namespace Refactoring
{
    public class InventoryUI : MonoBehaviour
    {
        private int lastInventorySize = 0;
        private Dictionary<string, InventorySlot> inventorySlots = new Dictionary<string, InventorySlot>();

        public List<GameObject> UISlots = new List<GameObject>();

        private List<Object> inventory;

        public GameObject inventoryPanel;


        void Start()
        {
            Inventory.instance.onInventoryChangedCallback += UpdateUI;
        }

        private void UpdateUI(string obj)
        {
            inventory = Inventory.instance.inventory;

            if (lastInventorySize > inventory.Count)
            {
                print("Update UI" + lastInventorySize + " " + inventory.Count);
                inventorySlots[obj].Decrease(lastInventorySize - inventory.Count);

            }
            else
            {
                for (int i = lastInventorySize; i < inventory.Count; i++)
                {
                    if (!inventorySlots.ContainsKey(inventory[i].name))
                    {
                        var slot = GetFreeSlot().GetComponent<InventorySlot>();
                        slot.Add(inventory[i]);

                        inventorySlots.Add(inventory[i].name, slot);
                    }
                    else
                    {
                        inventorySlots[inventory[i].name].Increase();
                    }
                }
            }
            lastInventorySize = inventory.Count;
        }

        private void UpdateUI2()
        {
            inventory = Inventory.instance.inventory;
            if (lastInventorySize > inventory.Count)
            {
                foreach (var item in inventorySlots)
                {

                }
                return;
            }
            for (int i = lastInventorySize; i < inventory.Count; i++)
            {
                if (!inventorySlots.ContainsKey(inventory[i].name))
                {
                    var slot = GetFreeSlot().GetComponent<InventorySlot>();
                    slot.Add(inventory[i]);

                    inventorySlots.Add(inventory[i].name, slot);
                }
                else
                {
                    inventorySlots[inventory[i].name].Add(inventory[i]);
                }
            }
            lastInventorySize = inventory.Count;
        }

        private GameObject GetFreeSlot()
        {
            foreach (var slot in UISlots)
            {
                if (!slot.activeSelf)
                {
                    return slot;
                }
            }
            return null;
        }

        public void OpenInventory()
        {
            inventoryPanel.SetActive(true);
        }
        public void CloseInventory()
        {
            inventoryPanel.SetActive(false);
        }
    }
}