using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer{

    void Buy(string name);
    bool TryToPay(int amount);

}
