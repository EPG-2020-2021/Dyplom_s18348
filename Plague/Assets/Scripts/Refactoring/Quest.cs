using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest<T> : Quest
{
    public QuestType type;
    
    public T specialParam;
    public int specialParamCount;

    public Quest(QuestType type, T specialParam, int specialParamCount)
    {
        this.type = type;
        this.specialParam = specialParam;
        this.specialParamCount = specialParamCount;
    }
}

public abstract class Quest
{
}

public enum QuestType
{
    Bring,
    BringSpecial,
    Heal,
    Craft,
    CraftSpecial
}
