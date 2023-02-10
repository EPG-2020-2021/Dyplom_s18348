using System;
using UnityEngine;

public class UIInventoryController : UIContainerController
{
    public UIInventoryController()
    {
    }

    public override void Init()
    {
        base.Init();
        this.container = PlayerScript.instance.inventory;
    }

    public void OpenClose()
    {
        base.gameObject.SetActive(!base.gameObject.activeSelf);
    }

    private void Start()
    {
        this.Init();
    }
}