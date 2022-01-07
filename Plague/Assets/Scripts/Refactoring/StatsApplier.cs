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
            characterStats.GetStat(stats[i].statKey).Increase(stats[i].value);
        }
    }
}
