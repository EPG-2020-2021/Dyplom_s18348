using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance; //single instance
    public List<GameObject> targets = null;

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
    [SerializeField]
    internal ShopCustomer shopCustomer;
    [SerializeField]
    internal Givable givable;
    [SerializeField]
    internal QuestMaster questMaster;

    private void Awake()
    {
        if (!instance) //singletone
        {
            instance = this;
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                Application.Quit();
            else
                SceneManager.LoadScene(0);
        }
    }

    private void Start()
    {
        print("PLAYERSCRIPT");
        SaveSystem.MasterLoad();
    }
}
