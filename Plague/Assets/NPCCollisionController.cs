using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollisionController : MonoBehaviour
{
    private NPCScript npc;

    private void Start()
    {
        npc = GetComponent<NPCScript>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<NPCContact>().closestNPC = npc;
            other.gameObject.GetComponent<NPCContact>().onNPCSetCallback?.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<NPCContact>().closestNPC = null;
            other.gameObject.GetComponent<NPCContact>().onNPCSetCallback?.Invoke();
        }
    }
}
