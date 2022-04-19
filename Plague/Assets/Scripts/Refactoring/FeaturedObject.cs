using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeaturedObject : Object, IUsable
{

    public void Use()
    {
        StatsApplier.ApplyStats(this.gameObject, PlayerScript.instance.gameObject);
    }

    public void Use(GameObject instance)
    {
        StatsApplier.ApplyStats(this.gameObject, instance);
    }
}
