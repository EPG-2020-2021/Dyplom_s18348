using System;
using UnityEngine;

public class StatsApplier : MonoBehaviour
{
    public StatsApplier()
    {
    }

    public static void ApplyStats(GameObject fromObject, GameObject toCharacter, bool overwrite = false)
    {
        Stat[] componentsInChildren = fromObject.GetComponentsInChildren<Stat>();
        CharacterStats component = toCharacter.GetComponent<CharacterStats>();
        for (int i = 0; i < (int)componentsInChildren.Length; i++)
        {
            if (!overwrite)
            {
                Stat stat = component.GetStat(componentsInChildren[i].statKey);
                if (stat != null)
                {
                    stat.Change(componentsInChildren[i].@value);
                }
                else
                {
                }
            }
            else
            {
                Stat stat1 = component.GetStat(componentsInChildren[i].statKey);
                if (stat1 != null)
                {
                    stat1.Set(componentsInChildren[i].@value);
                }
                else
                {
                }
            }
        }
        component.UpdateStatsText();
    }

    public static void CancelStats(GameObject fromObject, GameObject toCharacter)
    {
        Stat[] componentsInChildren = fromObject.GetComponentsInChildren<Stat>();
        CharacterStats component = toCharacter.GetComponent<CharacterStats>();
        for (int i = 0; i < (int)componentsInChildren.Length; i++)
        {
            component.GetStat(componentsInChildren[i].statKey).Change(-componentsInChildren[i].@value);
        }
        component.UpdateStatsText();
    }

    public static void RandomiseStats(GameObject obj)
    {
        Stat[] componentsInChildren = obj.GetComponentsInChildren<Stat>();
        for (int i = 0; i < (int)componentsInChildren.Length; i++)
        {
            componentsInChildren[i].SetRandomValue();
        }
    }

    public static void RewardStat(StatKey key, float amount)
    {
        CharacterStats component = PlayerScript.instance.playerStats;

        Stat stat = component.GetStat(key);
        if (stat != null)
        {
            stat.Change(amount);
        }
       
    }

}