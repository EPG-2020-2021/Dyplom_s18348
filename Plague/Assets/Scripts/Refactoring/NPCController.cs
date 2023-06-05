using System;
using UnityEngine;

internal class NPCController : MonoBehaviour
{
    [SerializeField]
    private NPCScript npc;

    public NPCController()
    {
    }

    public void SetItem(Object obj)
    {
        this.npc.PutObject(obj);
    }

    private void Start()
    {
    }

    public void Use()
    {
        Object obj = this.npc.GetObject();
        if (!obj || obj.GetComponent<IUsable>() == null)
        {
            return;
        }
        obj.GetComponent<IUsable>().Use(base.gameObject);
        this.npc.CleanSlot();
    }
}