using UnityEngine;

public class Object : MonoBehaviour, IInteractible, IPickable
{
    public new string name;
    public int cost;
    public Sprite icon;


    public void Interact()
    {
        pickUp();
    }

    public void pickUp()
    {
        print("PickUp");
    }
}
