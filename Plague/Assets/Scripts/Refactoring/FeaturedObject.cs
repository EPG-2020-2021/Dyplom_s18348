using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeaturedObject : Object, IUsable
{
    public void Use()
    {
        
    }

    public void Use(GameObject instance)
    {
        StatsApplier.ApplyStats(this.gameObject, instance);
    }
}
