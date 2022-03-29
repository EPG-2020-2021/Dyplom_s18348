using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image icon;
    private string objectName;
    public int number;

    //UIside

    public TextMeshProUGUI slotName;
    public TextMeshProUGUI objectsNumber;

    public void Add(Object obj, int number = 1)
    {
        //icon;
        this.objectName = obj.name;
        this.number = number;

        gameObject.SetActive(true);

        UpdateSlot();
    }

    public void Increase(int num = 1)
    {
        number += num;

        gameObject.SetActive(true);
        UpdateSlot();
    }

    public void Decrease(int num = 1)
    {
        number -= num;
        if (number <= 0)
        {
            Clear();
        }
        UpdateSlot();
    }

    public void Clear()
    {
        gameObject.SetActive(false);
    }

    private void UpdateSlot()
    {
        slotName.text = objectName;
        objectsNumber.text = number.ToString();
    }


    public void OnDecreaseButton()
    {
        Inventory.instance.Remove(objectName);
    }
}
