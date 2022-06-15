using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givable : MonoBehaviour
{
    [HideInInspector]
    public IGivable closest = null;


    public delegate void OnGivableSet();
    public OnGivableSet onGivableSetCallback;

}
