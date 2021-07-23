using UnityEngine;
using Random = System.Random;

public class Weapon : Item
{   
    public float Durability = 100f;
    public float maxDurability = 100f;

    Random rnd = new Random();
    
    public void OnUse()
    {
        Durability--;
        Break();
    }

    public void Break()
    {
        if (Durability < 15 && rnd.NextDouble() < 0.8)
        {
            GameObject.Destroy(gameObject);
        }
        if(Durability < 1)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
