using System;
using UnityEngine;

public class ShopCustomer : MonoBehaviour, IShopCustomer
{
    private bool isInited;

    private Inventory inventory;

    private Shop shop;

    private MoneyController moneyController;

    public ShopCustomer()
    {
    }

    public void Buy(Object item)
    {
        this.inventory.Add(item, null);
    }

    public void ExitShop()
    {
        this.shop = null;
    }

    public void Init()
    {
        if (this.isInited)
        {
            return;
        }
        this.inventory = PlayerScript.instance.inventory;
        this.moneyController = PlayerScript.instance.moneyController;
        this.isInited = true;
    }

    public void Sell(Object item)
    {
        if (this.inventory.Has(item))
        {
            this.shop.Add(item, null);
            this.inventory.Remove(item);
            this.moneyController.Earn(item.cost);
        }
    }

    public void SetShop(Shop shop)
    {
        this.shop = shop;
        this.Init();
    }

    public bool TryToPay(int amount)
    {
        if (amount > this.moneyController.GetMoneyAmount())
        {
            MonoBehaviour.print("Not enough money");
            return false;
        }
        this.moneyController.Spend(amount);
        return true;
    }
}