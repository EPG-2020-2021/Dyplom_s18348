using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventoryController : UIContainerController
{

    public void OpenClose()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public override void Init()
    {
        base.Init();
        container = PlayerScript.instance.inventory;
    }

    private void Start()
    {
        Init();
    }

}
