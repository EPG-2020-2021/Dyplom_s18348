using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance; //single instance
    public GameObject target = null;


    public float playerSpeed = 80f;

    [SerializeField] 
    internal PlayerCollisionController collisionController;
    [SerializeField]
    internal PlayerInteractionController interactionController;
    [SerializeField]
    internal PlayerInputController inputController;
    [SerializeField]
    internal PlayerMovementController movementController;


    private void Awake()
    {
        if (!instance) //singletone
        {
            instance = this;
        }
    }
}
