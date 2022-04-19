using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [HideInInspector]
    public Stat health;


    void Awake()
    {
        health = PlayerScript.instance.playerStats.GetStat(StatKey.Health);
    }

    public void Damage(float dmg)
    {
        health.Change(-dmg);
        CheckForDeath();
    }

    private void CheckForDeath()
    {
        if (GetHealth() <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Invoke death
    }

    public void Heal(float hp)
    {
        health.Change(hp);
    }

    public float GetHealth()
    {
        return health.value;
    }
}
