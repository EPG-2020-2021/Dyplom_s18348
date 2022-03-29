using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour, IShopCustomer, ISellshopCustomer
{
    private PlayerScript player;
    public int taxPercent;

    private void Start()
    {
        player = PlayerScript.instance;
    }

    public void Buy(string name)
    {
        player.inventory.Add(ItemManager.instance.GetObject(name));
    }

    public void Sell(string name)
    { int calculatedCost;
        if (Inventory.instance.DoesInventoryContains(name))
        {

            calculatedCost = ItemManager.instance.GetObject(name).cost * (100 - taxPercent)/100; 

            player.inventory.Remove(name);
            Earn(calculatedCost);
        }
        
    }

    public void Earn(int amount)
    {
        player.money += amount;
    }
    public bool TryToPay(int amount)
    {
        
        if (amount <= player.money)
        {
            player.money -= amount;
            print("Enough money");
            return true;
        }
        else
        {
            print("Not enough money");
            return false;
        }
    }
}
