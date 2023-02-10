using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [HideInInspector]
    public Stat health;

    public PlayerHealthController()
    {
    }

    private void Awake()
    {
        this.health = PlayerScript.instance.playerStats.GetStat(StatKey.Health);
        PlayerScript.instance.playerStats.GetStat(StatKey.Health).onValueChange += new Stat.OnValueChange(this.CheckForDeath);
    }

    private void CheckForDeath()
    {
        MonoBehaviour.print(this.GetHealth());
        if (this.GetHealth() <= 0f)
        {
            base.StartCoroutine(this.Die());
        }
    }

    private IEnumerator Die()
    {
        MonoBehaviour.print("You died");
        yield return new WaitForSeconds(0.5f);
        SaveSystem.DeleteSaves();
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }

    public float GetHealth()
    {
        return PlayerScript.instance.playerStats.GetStat(StatKey.Health).@value;
    }
}