using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance; //single instance
    public GameObject target = null;


    [SerializeField] 
    internal PlayerCollisionController collisionController;
    [SerializeField]
    internal PlayerInteractionController interactionController;
    [SerializeField]
    internal PlayerInputController inputController;
    [SerializeField]
    internal PlayerMovementController movementController;
    [SerializeField]
    internal CharacterStats playerStats;
    [SerializeField]
    internal PlayerHealthController healthController;
    [SerializeField]
    internal Inventory inventory;
    [SerializeField]
    internal CharacterAnimationController animationController;
    [SerializeField]
    internal MoneyController moneyController;

    private void Awake()
    {
        if (!instance) //singletone
        {
            instance = this;
        }
    }
}
