using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    internal UIHealthController healthController;
    [SerializeField]
    internal UIInventoryController inventoryController;
    [SerializeField]
    internal UIShop shopUi;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
}
