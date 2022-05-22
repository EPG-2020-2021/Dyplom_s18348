using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput controls;

    private void Awake()
    {
        controls = new PlayerInput();
    }

    private void Start()
    {
        controls.Player.Interact.performed += _ 
            => PlayerScript.instance.interactionController.Interact();
        controls.Player.Move.performed += ctx 
            => PlayerScript.instance.movementController.Move(new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y)); 
        controls.Player.Move.canceled += _ 
            => PlayerScript.instance.movementController.Move(Vector3.zero);
        controls.PlayerUI.Inventory.performed += _ => UIManager.instance.inventoryController.OpenClose();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}