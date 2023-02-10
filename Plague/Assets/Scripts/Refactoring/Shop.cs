using System;
using UnityEngine;

public class Shop : ItemContainer
{
    public Shop()
    {
    }

    private void Start()
    {
        this.containerFiller = base.GetComponent<ContainerFiller>();
        this.containerController = UIManager.instance.shopUi;
        this.containerController.Init();
        this.inventorySize = this.containerController.GetSize();
        this.containerFiller.Fill();
    }
}