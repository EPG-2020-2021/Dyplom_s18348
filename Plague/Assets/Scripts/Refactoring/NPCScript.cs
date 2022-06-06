using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField]
    private Object slot;

    //DialogController dialogController;

    [SerializeField]
    internal CharacterStats characterStats;
    [SerializeField]
    internal NPCController npcController;
    [SerializeField]
    internal NPCCollisionController npcCollisionController;

    public void PutObject(Object obj)
    {
        if (slot == null)
        {
            slot = obj;
        }
    }

    public Object TakeObject()
    {
        if (slot == null)
        {
            return new Object();
        }

        var result = slot;
        slot = null;
        return result;
    }

    public Object GetObject()
    {
        if (slot == null)
        {
            return new Object();
        }

        return slot; 
    }

}
