using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ItemContainer
{


    private void Start()
    {
        containerFiller = GetComponent<ContainerFiller>();
        containerController = UIManager.instance.inventoryController;
        containerController.Init();
        inventorySize = containerController.GetSize();
    }
}
