using System;

[Serializable]
public class MoneyData
{
    private int money;

    public MoneyData(int money)
    {
        this.money = money;
    }

    public int GetMoney()
    {
        return this.money;
    }
}