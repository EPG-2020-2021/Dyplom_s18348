using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsApplier : MonoBehaviour
{
    public static void ApplyStats(GameObject fromObject, GameObject toCharacter)
    {
        var stats = fromObject.GetComponentsInChildren<Stat>();
        var characterStats = toCharacter.GetComponent<CharacterStats>();

        for (int i = 0; i < stats.Length; i++)
        {
             characterStats.GetStat(stats[i].statKey)?.Change(stats[i].value); 
        }

        characterStats.UpdateStatsText();
    }

    public static void CancelStats(GameObject fromObject, GameObject toCharacter)
    {
        var stats = fromObject.GetComponentsInChildren<Stat>();
        var characterStats = toCharacter.GetComponent<CharacterStats>();

        for (int i = 0; i < stats.Length; i++)
        {
            characterStats.GetStat(stats[i].statKey).Change(-stats[i].value);
        }

        characterStats.UpdateStatsText();
    }

    public static void RandomiseStats(GameObject obj)
    {
        var stats = obj.GetComponentsInChildren<Stat>();

        foreach (var stat in stats)
        {
            stat.SetRandomValue();
        }
    }
}
