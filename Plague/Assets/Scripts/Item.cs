﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{

    public string ItemName;

    public bool craftability;

    public int itemQuality = 100;

    public SpriteRenderer icon;

    public List<string> good = new List<string>();
    public List<string> bad = new List<string>();


    public void Start()
    {
        icon = GetComponent<SpriteRenderer>();
    }
    public List<string> GetGoodFeatures()
    {
        return good;
    }
    public List<string> GetBadFeatures()
    {
        return bad;
    }
    public void SetGoodFeatures(List<string> list)
    {
        good = list;
    }
    public void SetBadFeatures(List<string> list)
    {
        bad = list;
    }
    public void AddGoodFeature(string feature)
    {
        good.Add(feature);
    }
    public void AddBadFeature(string feature)
    {
        bad.Add(feature);
    }

    public void DestroySelf()
    {
        transform.gameObject.active = false;
        
    }

}

[Serializable]
class ItemSave{
    
    public string ItemName;

    public bool craftability;

    public int itemQuality;

    public List<string> good = new List<string>();
    public List<string> bad = new List<string>();

    public ItemSave(Item item)
    {
        ItemName = item.ItemName;
        craftability = item.craftability;
        itemQuality = item.itemQuality;

        good = item.GetGoodFeatures();
        bad = item.GetBadFeatures();
    }
    public ItemSave()
    {

    }
}
