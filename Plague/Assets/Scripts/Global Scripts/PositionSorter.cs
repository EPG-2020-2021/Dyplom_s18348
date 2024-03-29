﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSorter : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;
    [SerializeField]
    private int offset = 0;
    private Renderer renderer;

    private void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }
   

    void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset); 
    }
}
