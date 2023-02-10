using System;
using UnityEngine;

public class Givable : MonoBehaviour
{
    [HideInInspector]
    public IGivable closest;

    public GameObject obj;

    public Givable.OnGivableSet onGivableSetCallback;

    public Givable()
    {
    }

    public delegate void OnGivableSet();
}