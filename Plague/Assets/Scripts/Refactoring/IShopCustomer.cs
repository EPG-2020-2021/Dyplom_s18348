using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    void Sell(Object item);
    void Buy(Object item);
    bool TryToPay(int amount);
}
