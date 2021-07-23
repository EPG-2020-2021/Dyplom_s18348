using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public string ItemName;
    public bool craftability;
    public SpriteRenderer icon;
    public float Cost = 0f;

    public void Start()
    {
        icon = GetComponent<SpriteRenderer>();
    }
    
    public void DestroySelf()
    {
        transform.gameObject.active = false;
    }
}


