using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{

    public Stats stats;

    public float dmg = 5;
    public float heal = 5;
    public void OnButton()
    {
        stats.Damage(dmg, DamageType.Plague);
    }public void OnButton2()
    {
        stats.Heal(heal);
    }

    public void Save()
    {
        SaveSystem.SaveStats(PlayerScript.instance.playerStats);
    }

    public void Load()
    {
        SaveSystem.LoadStats(PlayerScript.instance.playerStats);
    }
}
