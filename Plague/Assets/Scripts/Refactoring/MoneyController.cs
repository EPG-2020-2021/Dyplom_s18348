using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    private int _money = 0;

    public delegate void OnMoneyChange();
    public OnMoneyChange onMoneyChangeCallback;

    public int GetMoneyAmount()
    {
        return _money;
    }

    public void Earn(int amount)
    {
        _money += amount;
        onMoneyChangeCallback?.Invoke();
    }

    public void Spend(int amount)
    {
        if (_money >= amount)
        {
            _money -= amount;
            onMoneyChangeCallback?.Invoke();
            return;
        }

        print("Not enough money");
    }
}
