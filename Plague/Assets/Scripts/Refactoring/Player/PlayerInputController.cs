using UnityEngine;
internal class PlayerInputController : MonoBehaviour
{

    [SerializeField]
    public PlayerInput controls;

    private void Awake()
    {
        controls.Player.Interact.performed += _ => PlayerScript.instance.interactionController.Interact();
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