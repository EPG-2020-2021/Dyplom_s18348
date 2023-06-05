using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest<T> : Quest
{
    public string questName;
    public string questDescription;

    public QuestType type;
    
    public T specialParam;
    public int specialParamCount;
    public string itemName;

    public delegate void OnComplete();
    public OnComplete onCompleteCallback;

    public delegate void OnCompleted(GameObject obj);
    public OnComplete onCompletedCallback;

    public bool completed = false;

    public GameObject uiUnit;

    //reward

    private StatKey statKey = StatKey.Decription; //Default value
    private float rewardAmount = 2; //Default value

    public void Complete()
    {
        Debug.Log("Complete " + questName);

        onCompleteCallback?.Invoke();
        QuestMaster.ReleaseQuest(this);
        PlayerScript.instance.inventory.onNewItemCallback -= CheckForItem;
        StatsApplier.RewardStat(statKey, rewardAmount);
        
        completed = true;

        SaveSystem.SaveQuest(questName, completed);
    }

    public Quest(string name, string description, QuestType type, T specialParam, int specialParamCount)
    {
        this.questName = name;
        this.questDescription = description;
        this.type = type;
        this.specialParam = specialParam;
        this.specialParamCount = specialParamCount;

        completed = SaveSystem.LoadQuest(name);

        if (completed) return;

        if (type.Equals(QuestType.FindSpecial))
        {
            CheckForAll();
            PlayerScript.instance.inventory.onNewItemCallback += CheckForItem;
        }
    }

    internal void DestroySelf()
    {
        Debug.Log("Destroy");
        GameObject.Destroy(uiUnit);
    }

    public Quest(string name, string description, QuestType type, string itemName)
    {
        this.questName = name;
        this.questDescription = description;
        this.type = type;
        this.itemName = itemName;

        completed = SaveSystem.LoadQuest(name);

        if (completed) return;

        if (type.Equals(QuestType.Find))
        {
            CheckForAll();
            PlayerScript.instance.inventory.onNewItemCallback += CheckForItem;
        }
    }

    private void CheckForItem(Object item)
    {

        if (completed) return;

        Stat stat = new Stat();

        try
        {
            stat = item.gameObject?.GetComponentsInChildren<Stat>()?.First(x => x.statKey.Equals(specialParam) && x.value >= specialParamCount); //Find needed stat if exist
        }catch(Exception e)
        {

        };

        if (type.Equals(QuestType.Find) && item.name.Equals(this.itemName))
        {
            Complete();
            PlayerScript.instance.inventory.containerController.GetSlotWithItem(item)?.Remove();
            return;
        }
        else if (type.Equals(QuestType.FindSpecial) && stat)
        {
            Complete();
            PlayerScript.instance.inventory.containerController.GetSlotWithItem(item)?.Remove();
            return;
        }

    }

    public void SetReward(int reward)
    {
        if (reward <= 0) return;
        else rewardAmount = reward;
    }

    private void CheckForAll()
    {
        foreach (var item in PlayerScript.instance.inventory.container)
        {
            CheckForItem(item); 
                if(completed) return;

        }
    }


}

public abstract class Quest
{

}

public enum QuestType
{
    Find,
    FindSpecial,
    Heal,
    Craft,
    CraftSpecial
}
