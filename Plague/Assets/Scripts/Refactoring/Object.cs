using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour, IInteractible, IPickable
{

    public new string name;
    public string description;
    public int cost;
    public Sprite icon;

    //public Object(string name)
    //{
    //    this.name = name;
    //}
    public void Interact()
    {
        pickUp();  
    }

    public void pickUp()
    {
        PlayerScript.instance.inventory.Add(this);
        gameObject.SetActive(false);
    }
}
