using System;
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

    public UIManager()
    {
    }

    private void Awake()
    {
        if (!UIManager.instance)
        {
            UIManager.instance = this;
        }
        this.craftUi.onCraftUpdateCallback += new UIContainerController.OnContainerUpdate(this.craftUi.ShowHide);
    }

    private void Start()
    {
        PlayerScript.instance.moneyController.onMoneyChangeCallback += new MoneyController.OnMoneyChange(this.UpdateMoney);
    }

    private void UpdateMoney()
    {
        TextMeshProUGUI str = this.money;
        int moneyAmount = PlayerScript.instance.moneyController.GetMoneyAmount();
        str.text = moneyAmount.ToString();
    }
}