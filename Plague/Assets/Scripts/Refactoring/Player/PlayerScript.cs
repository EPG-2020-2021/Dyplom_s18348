using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance; //single instance
    public GameObject target;



    [SerializeField] 
    internal PlayerCollisionController collisionController;
    [SerializeField]
    internal PlayerInteractionController interactionController;
    [SerializeField]
    internal PlayerInputController inputController;


    private void Awake()
    {
        if (!instance) //singletone
        {
            instance = this;
        }
    }



}
