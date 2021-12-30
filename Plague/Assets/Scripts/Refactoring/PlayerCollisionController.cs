using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void Start()
    {
        if(!PlayerScript.instance.collisionController)
        PlayerScript.instance.collisionController = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerScript.instance.target = other.gameObject;
    }
}
