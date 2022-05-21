using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : ItemContainer
{

    private void Start()
    {
        containerController = UIManager.instance.shopUi;
        containerController.Init();
        inventorySize = containerController.GetSize();
    }

}
