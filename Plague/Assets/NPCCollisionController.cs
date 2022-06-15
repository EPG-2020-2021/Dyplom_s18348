using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollisionController : MonoBehaviour
{
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
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Givable>().closest = null;
            other.gameObject.GetComponent<Givable>().onGivableSetCallback?.Invoke();
        }
    }
}
