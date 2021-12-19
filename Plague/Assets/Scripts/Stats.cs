using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private float health = 100;
    private float experience = 0f;
    public float maxHealth = 100;
    public float minHealth = 0;


    private float plagueProtection = 1; //in %
    //float physicsProtection = 0; //in %


    StatsGUI statsGUI;


    private void Start()
    {
        statsGUI = StatsGUI.instance;
    }
    public void Damage(float dmg, DamageType type)
    {
        //FOR %
        //if (type.Equals(DamageType.Plague))
        //{
        //    dmg *= 1 - (plagueProtection / 100);
        //}
        if (type.Equals(DamageType.Plague))
        {
            dmg -= plagueProtection;
            if (dmg < 0)
                dmg = 0;
        }
        if (health - dmg >= minHealth)
        {
            health -= dmg;
        }
        else
        {
            health = minHealth;
        }
        print($"get damage: {dmg}");
        print($"health: {health}");
        statsGUI.SetHealth(health);
    }

    public void Heal(float hp)
    {
        if (health + hp <= maxHealth)
        {
            health += hp;
        }
        else
        {
            health = maxHealth;
        }
        
        print($"fealed: {hp}");
        print($"health: {health}");
        statsGUI.SetHealth(health);
    }

    public void addExp(float exp)
    {
        experience += exp;
        print($"+{exp}");
        print($"experience: {experience}");
    }
   
    void FixedUpdate()
    {
        
    }
}

public enum DamageType
{
    Physical,
    Plague
}