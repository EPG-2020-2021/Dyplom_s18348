using System;
using UnityEngine;

public class StatsApplier : MonoBehaviour
{
    public StatsApplier()
    {
    }

    public static void ApplyStats(GameObject fromObject, GameObject toCharacter, bool overwrite = false)
    {

        Stat[] statsFromItem = fromObject.GetComponentsInChildren<Stat>();
        CharacterStats characterStats = toCharacter.GetComponent<CharacterStats>();
        for (int i = 0; i < (int)statsFromItem.Length; i++)
        {
            if (!overwrite)
            {
                Stat stat = characterStats.GetStat(statsFromItem[i].statKey);

                

                if (stat != null)
                {
                    stat.Change(statsFromItem[i].value);
                }
                else
                {
                }
            }
            else
            {
                Stat stat1 = characterStats.GetStat(statsFromItem[i].statKey);
                if (stat1 != null)
                {
                    stat1.Set(statsFromItem[i].@value);
                }
                else
                {
                }
            }
        }
        characterStats.UpdateStatsText();
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

        print(key + " " + stat.name + " " + amount);
        if (stat != null)
        {
            stat.Change(amount);
        }

        component.UpdateStatsText();
    }

}