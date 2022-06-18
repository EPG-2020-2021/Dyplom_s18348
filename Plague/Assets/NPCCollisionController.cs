using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCCollisionController : MonoBehaviour
{
    public NPCScript npcScript;
    private IGivable npc;
    
    private void Start()
    {
        npc = GetComponent<IGivable>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Givable>().closest = npc;
            other.gameObject.GetComponent<Givable>().onGivableSetCallback?.Invoke();

            npcScript.npcUI.Show();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Givable>().closest = null;
            other.gameObject.GetComponent<Givable>().onGivableSetCallback?.Invoke();

            npcScript.npcUI.Hide();
        }
    }
}
