using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem)
    {
        print(newItem.ItemName);
        item = newItem;
        icon.sprite = item.icon.sprite;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void OnItemButton()
    {
       print(item.GetComponent<Weapon>().Durability);
    }
}
