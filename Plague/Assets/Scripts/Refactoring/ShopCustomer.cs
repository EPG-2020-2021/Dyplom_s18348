using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCustomer : MonoBehaviour, IShopCustomer
{
    private bool isInited = false;

    private Inventory inventory;
    private Shop shop;
    private MoneyController moneyController;



    public void Buy(Object item)
    {
        inventory.Add(item);
        //shop.Remove(item);
    }

    public void Sell(Object item)
    {
        if (inventory.Has(item))
        {

            shop.Add(item);

            inventory.Remove(item);

            moneyController.Earn(item.cost);
        }
    }

    public bool TryToPay(int amount)
    {
        if (amount <= moneyController.GetMoneyAmount())
        {
            moneyController.Spend(amount);
            return true;
        }
        else
        {
            print("Not enough money");
            return false;
        }
    }

    public void SetShop(Shop shop)
    {
        this.shop = shop;

        Init();
    }

    public void ExitShop()
    {
        shop = null;
    }

    public void Init()
    {
        if (isInited)
        {
            return;
        }

        inventory = PlayerScript.instance.inventory;
        moneyController = PlayerScript.instance.moneyController;

        isInited = true;
    }
}
