using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCollisionController : MonoBehaviour
{
    private UIShop shopUi;
    private void Start()
    {
        shopUi = UIManager.instance.shopUi;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<IShopCustomer>() != null)
        //{
        
        UIManager.instance.shopUi.container = GetComponent<ItemContainer>();
        UIManager.instance.shopUi.SetShopCustomer(other?.GetComponent<IShopCustomer>());
        UIManager.instance.shopUi.onShopUpdateCallback?.Invoke();


        //}

    }

    private void OnTriggerExit(Collider other)
    {
        if (UIManager.instance.shopUi.GetShopCustomer().Equals(other?.GetComponent<IShopCustomer>()))
        {
            UIManager.instance.shopUi.ClearCustomer();
        }
        if (UIManager.instance.shopUi.container.Equals(GetComponent<ItemContainer>()))
        {
            UIManager.instance.shopUi.container = null;
        }

        UIManager.instance.shopUi.onShopUpdateCallback?.Invoke();
    }
}
