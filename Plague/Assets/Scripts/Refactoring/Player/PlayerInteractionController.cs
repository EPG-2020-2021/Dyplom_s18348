using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    
    public void Interact()
    {
        var target = PlayerScript.instance.target.GetComponent<IInteractible>();

        if (target == null)
        {
            return;
        }

        target.Interact();
    }

    public void Use()
    {
        var target = PlayerScript.instance.target.GetComponent<IUsable>();

        if (target == null)
        {
            return;
        }

        target.Use();

    }

}
