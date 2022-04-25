using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCustomer : MonoBehaviour, IShopCustomer
{
    private bool isInited = false;

    private Inventory inventory;
    private MoneyController moneyController;

    public void Buy(Object item)
    {
        inventory.Add(item);
    }

    public void Sell(Object item)
    {
        if (inventory.Has(item))
        {

            //Add item to shop

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
