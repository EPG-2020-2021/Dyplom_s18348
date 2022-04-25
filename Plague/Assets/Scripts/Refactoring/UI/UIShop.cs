using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour, IInteractable
{
    private Transform container;
    private Transform shopItemTemplate;

    private IShopCustomer shopCustomer;



    public void Sell(Object item)
    {
        shopCustomer.Sell(item);
    }

    public void TryToBuy(Object item)
    {
        if (shopCustomer.TryToPay(item.cost))
        {
            shopCustomer?.Buy(item);
        }
        
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void OpenClose()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }


    private void Awake()
    {
       
    }

}
