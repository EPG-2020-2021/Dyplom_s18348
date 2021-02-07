using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Item item;


    bool ableToInteract = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.gameObject.CompareTag("Player"))
        {
            ableToInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ableToInteract = false;
        }
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
        item.DestroySelf();
    
    }

}
