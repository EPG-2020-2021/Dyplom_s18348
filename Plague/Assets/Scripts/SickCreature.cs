using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickCreature : Creature
{
    public GameObject leechSystem;
    public override void Interaction()
    {

        Instantiate(leechSystem, GameObject.Find("Canvas").transform);
      
        //base.Interaction();
    }
}
