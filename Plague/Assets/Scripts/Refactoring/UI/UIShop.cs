using System;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : UIContainerController
{
    private IShopCustomer shopCustomer;

    public UIContainerController.OnContainerUpdate onShopUpdateCallback;

    [HideInInspector]
    public bool isOpened;


    private bool opened = true;

    public UIShop()
    {
    }

    public void ClearCustomer()
    {
        this.shopCustomer = null;
        this.Close();
    }

    public void Close()
    {
        base.gameObject?.SetActive(false);
    }

    public void Fill()
    {
        for (int i = 0; i < this.slots.Count; i++)
        {
            if (i >= this.container.container.Count)
            {
                this.slots[i].Remove();
            }
            else
            {
                this.slots[i].item = this.container.container[i];
            }
        }
        UIContainerController.OnContainerUpdate onContainerUpdate = this.onContainerUpdateCallback;
        if (onContainerUpdate == null)
        {
            return;
        }
        onContainerUpdate();
    }

    public IShopCustomer GetShopCustomer()
    {
        return this.shopCustomer;
    }

    public override void Init()
    {
        base.Init();


        TimeManage.onDayStartCallback += OpenShop;
        TimeManage.onNightStartCallback += CloseShop;
    }

    public void Sell(Object item)
    {
        this.shopCustomer.Sell(item);
    }

    public void SetShopCustomer(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        this.Init();
    }

    public void ShowHide()
    {
        if (!this.container || !opened)
        {
            return;
        }
        base.gameObject.SetActive(!base.gameObject.activeSelf);
        this.Fill();
    }

    public bool TryToBuy(Object item)
    {
        if (!this.shopCustomer.TryToPay(item.cost))
        {
            return false;
        }
        IShopCustomer shopCustomer = this.shopCustomer;
        if (shopCustomer != null)
        {
            shopCustomer.Buy(item);
        }
        else
        {
        }
        return true;
    }

    private void OpenShop()
    {
        opened = true;
    }
    private void CloseShop()
    {
        opened = false;
        Close();

    }

    public delegate void OnShopSet();
}