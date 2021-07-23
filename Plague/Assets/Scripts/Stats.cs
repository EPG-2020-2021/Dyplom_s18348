using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    float health = 100;
    float experience = 0f;

    float plagueProtection = 0; //in %
    //float physicsProtection = 0; //in %




    public void Damage(float dmg)
    {
        health -= dmg;
        print($"get damage: {dmg}");
        print($"health: {health}");
    }

    public void addExp(float exp)
    {
        experience += exp;
        print($"+{exp}");
        print($"experience: {exp}");
    }
   
    void FixedUpdate()
    {
        
    }
}
