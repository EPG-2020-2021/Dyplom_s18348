using System;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    private int _money;

    public MoneyController.OnMoneyChange onMoneyChangeCallback;

    public MoneyController()
    {
    }

    public void Earn(int amount)
    {
        this._money += amount;
        SaveSystem.SaveMoney();
        MoneyController.OnMoneyChange onMoneyChange = this.onMoneyChangeCallback;
        if (onMoneyChange == null)
        {
            return;
        }
        onMoneyChange();
    }

    public int GetMoneyAmount()
    {
        return this._money;
    }

    public void Set(int amount)
    {
        this._money = amount;
        MoneyController.OnMoneyChange onMoneyChange = this.onMoneyChangeCallback;
        if (onMoneyChange == null)
        {
            return;
        }
        onMoneyChange();
    }

    public void Spend(int amount)
    {
        if (this._money < amount)
        {
            MonoBehaviour.print("Not enough money");
            return;
        }
        this._money -= amount;
        SaveSystem.SaveMoney();
        MoneyController.OnMoneyChange onMoneyChange = this.onMoneyChangeCallback;
        if (onMoneyChange == null)
        {
            return;
        }
        onMoneyChange();
    }

    public delegate void OnMoneyChange();
}