using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour, IInteractible, IPickable
{
    public new string name;
    public int cost;










    public void Interact()
    {
        pickUp();
    }

    public void pickUp()
    {
        
    }
}
