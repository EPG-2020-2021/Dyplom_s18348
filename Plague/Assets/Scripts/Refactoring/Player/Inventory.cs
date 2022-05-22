using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ItemContainer
{


    private void Start()
    {
        containerController = UIManager.instance.inventoryController;
        containerController.Init();
        inventorySize = containerController.GetSize();
    }
}
