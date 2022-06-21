using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]
    internal CraftUIController craftUi;
    public TextMeshProUGUI money;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        craftUi.onCraftUpdateCallback += craftUi.ShowHide;
    }

    private void Start()
    {

        PlayerScript.instance.moneyController.onMoneyChangeCallback += UpdateMoney;
    }
    private void UpdateMoney()
    {
        money.text = PlayerScript.instance.moneyController.GetMoneyAmount().ToString();
    }
}
