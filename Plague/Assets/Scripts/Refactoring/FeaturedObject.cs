using System;
using UnityEngine;

public class FeaturedObject : Object, IUsable
{
    public FeaturedObject()
    {
    }

    public void Use()
    {
        StatsApplier.ApplyStats(base.gameObject, PlayerScript.instance.gameObject, false);
    }

    public void Use(GameObject instance)
    {
        StatsApplier.ApplyStats(base.gameObject, instance, false);
    }
}