﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
   public void Craft()
    {
        CraftTable.instance.Craft();
    }
}
