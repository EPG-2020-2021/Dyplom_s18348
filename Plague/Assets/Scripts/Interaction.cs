using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Item item;


    bool ableToInteract = false;
    GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject;
            ableToInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = null;
            ableToInteract = false;
        }
    }

    private void Awake()
    {
        item = GetComponent<Item>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && ableToInteract)
        {
            Interact();
        }
    }


    public virtual void Interact()
    {

        Inventory.instance.Add(item);
        transform.SetParent(Player.transform.GetChild(0));
        item.DestroySelf();
    }

}
