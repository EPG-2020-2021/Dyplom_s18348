using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : Weapon2
{

    private void Start()
    {
        base.Start();
        ItemName = "sickle";
    }
    public void Sharpen(float durability)
    {
        if(Durability + durability <= maxDurability)
        Durability += durability;
        maxDurability *= 0.8f;
    }
}
