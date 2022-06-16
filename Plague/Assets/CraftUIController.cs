using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftUIController : UIContainerController
{

    public OnContainerUpdate onCraftUpdateCallback;

    public void ShowHide()
    {
        gameObject.SetActive(UIManager.instance.craftUi.container);
    }
    public override void Init()
    {
        base.Init();

    }

    private void Start()
    {
        Init();
    }

    public void Craft()
    {
        container.gameObject.GetComponent<Table>().Craft();
    }

}
