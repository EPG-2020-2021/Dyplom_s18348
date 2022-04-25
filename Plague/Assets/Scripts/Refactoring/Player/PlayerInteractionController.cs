using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{    
    public void Interact()
    {
        print("Interacting");
        var temp = PlayerScript.instance.target;
        if (!temp || temp.GetComponent<IInteractable>() == null)
        {
            return;
        }
        var target = temp.GetComponent<IInteractable>();

        

        target.Interact();
    }

    public void Use()
    {
        var temp = PlayerScript.instance.target;
        if (!temp || temp.GetComponent<IUsable>() == null)
        {
            return;
        }
        var target = temp.GetComponent<IUsable>();

        target.Use(gameObject);

    }

}
