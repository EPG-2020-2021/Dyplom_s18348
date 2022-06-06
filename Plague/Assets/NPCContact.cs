using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCContact : MonoBehaviour
{
    [HideInInspector]
    public NPCScript closestNPC = null;


    public delegate void OnNPCSet();
    public OnNPCSet onNPCSetCallback;

}
