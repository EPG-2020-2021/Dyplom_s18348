using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour, IInteractible
{
    private IShopCustomer shopCustomer;
    private ISellshopCustomer sellshopCustomer;


    public GameObject shopUI;

    public void TryBuyObject(string name)
    {
        if (shopCustomer.TryToPay(ItemManager.instance.GetObject(name).cost))
        {
            shopCustomer.Buy(name);
        }
    }

    public void SellObject(string name)
    {
        sellshopCustomer.Sell(name);
    }


    public void Interact()
    {
        shopCustomer = PlayerScript.instance.gameObject.GetComponent<IShopCustomer>();
        sellshopCustomer = PlayerScript.instance.gameObject.GetComponent<ISellshopCustomer>();

        shopUI.SetActive(true);
    }

    public void OnCloseButton()
    {
        shopUI.SetActive(false);
    }
}
