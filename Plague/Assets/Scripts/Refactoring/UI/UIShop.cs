using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIShop : UIContainerController
{
    private IShopCustomer shopCustomer;

    public delegate void OnShopSet();
    public OnContainerUpdate onShopUpdateCallback;

    [HideInInspector]
    public bool isOpened = false;

    public override void Init()
    {
        base.Init();

    }

    public void Sell(Object item)
    {
        shopCustomer.Sell(item);
    }

    public bool TryToBuy(Object item)
    {
        if (shopCustomer.TryToPay(item.cost))
        {
            shopCustomer?.Buy(item);
            return true;
        }
        return false;
    }

    public void ShowHide()
    {
        if (!container) return;
       
        gameObject.SetActive(!gameObject.activeSelf);
        Fill();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }


    public void SetShopCustomer(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;

        Init();
    }

    public IShopCustomer GetShopCustomer()
    {
        return shopCustomer;
    }

    public void ClearCustomer()
    {
        shopCustomer = null;

        Close();
    }

    public void Fill()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < container.container.Count)
            {
                slots[i].item = container.container[i];
                continue;
            }
            slots[i].Remove();
        }
        onContainerUpdateCallback?.Invoke();
    }

}
