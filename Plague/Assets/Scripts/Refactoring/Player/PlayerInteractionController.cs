using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{    
    public void Interact()
    {
        print("Interacting");

        if (PlayerScript.instance.targets.Count < 1) return;

        var temp = PlayerScript.instance.targets[0];
        if (!temp || temp.GetComponent<IInteractable>() == null)
        {
            return;
        }
        var target = temp.GetComponent<IInteractable>();

        

        target.Interact();
    }

    public void Use()
    {
        if (PlayerScript.instance.targets.Count < 1) return;

        var temp = PlayerScript.instance.targets[0];
        if (!temp || temp.GetComponent<IUsable>() == null)
        {
            return;
        }
        var target = temp.GetComponent<IUsable>();

        target.Use(gameObject);

    }

}
