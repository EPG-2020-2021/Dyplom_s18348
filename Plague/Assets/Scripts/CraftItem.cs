using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItem : Item
{
    public int itemQuality = 0;

    public List<string> good = new List<string>();
    public List<string> bad = new List<string>();

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
        // Debug.Log(feature);
        good.Add(feature);
    }
    public void AddBadFeature(string feature)
    {
        bad.Add(feature);
    }
}

[Serializable]
class ItemSave
{

    public string ItemName;

    public bool craftability;

    public int itemQuality;

    public List<string> good = new List<string>();
    public List<string> bad = new List<string>();

    public ItemSave(CraftItem item)
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
