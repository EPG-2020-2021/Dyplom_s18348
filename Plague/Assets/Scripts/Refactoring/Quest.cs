using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest<T> : Quest
{
    public string QuestName;
    public string QuestDescription;

    public QuestType type;
    
    public T specialParam;
    public int specialParamCount;
    public string itemName;

    public delegate void OnComplete();
    public OnComplete onCompleteCallback;

    private bool completed = false;


    public void Complete()
    {
        onCompleteCallback?.Invoke();
        QuestMaster.ReleaseQuest(this);
        PlayerScript.instance.inventory.onNewItemCallback -= CheckForItem;
        completed = true;
    }

    public Quest(QuestType type, T specialParam, int specialParamCount)
    {
        this.type = type;
        this.specialParam = specialParam;
        this.specialParamCount = specialParamCount;

        if (type.Equals(QuestType.Find) || type.Equals(QuestType.FindSpecial))
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
            Debug.Log(stat.statKey + " " + stat.value);
        if (type.Equals(QuestType.Find) && item.name.Equals(this.itemName))
        {
            PlayerScript.instance.inventory.Remove(item);
            Complete();
        }
        else if (type.Equals(QuestType.FindSpecial) && stat)
        {
            Debug.Log("Complete");
            PlayerScript.instance.inventory.Remove(item);
            Complete();
        }
    }

    private void CheckForAll()
    {
        foreach (var item in PlayerScript.instance.inventory.container)
        {
            CheckForItem(item);
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
