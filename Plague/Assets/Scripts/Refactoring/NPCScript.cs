using System;
using UnityEngine;

public class NPCScript : MonoBehaviour, IGivable
{
    [SerializeField]
    private Object slot;

    [SerializeField]
    internal CharacterStats characterStats;

    [SerializeField]
    internal NPCController npcController;

    [SerializeField]
    internal NPCCollisionController npcCollisionController;

    [SerializeField]
    internal NpcUi npcUI;

    public NPCScript()
    {
    }

    public Object GetObject()
    {
        if (this.slot == null)
        {
            return new Object();
        }
        return this.slot;
    }

    public void PutObject(Object obj)
    {
        if (this.slot == null)
        {
            this.slot = obj;
        }
        this.npcController.Use();
        if (this.characterStats.Cured())
        {
            base.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public Object TakeObject()
    {
        if (this.slot == null)
        {
            return new Object();
        }
        Object obj = this.slot;
        this.slot = null;
        return obj;
    }
}