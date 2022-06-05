using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : ItemContainer
{

    private void Start()
    {
        containerFiller = GetComponent<ContainerFiller>();
        containerController = UIManager.instance.shopUi;
        containerController.Init();
        inventorySize = containerController.GetSize();

        containerFiller.Fill();
    }

}
