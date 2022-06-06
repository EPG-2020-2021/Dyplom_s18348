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
        if (other.GetComponent<IInteractable>() != null)
        {
            PlayerScript.instance.target = other.gameObject;
        }

        if (other.GetComponent<Shop>() != null)
        {
            PlayerScript.instance.shopCustomer.SetShop(other.GetComponent<Shop>());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (PlayerScript.instance.target && PlayerScript.instance.target.Equals(other.gameObject))
        {
            PlayerScript.instance.target = null;
        }

        if (other.GetComponent<Shop>() != null)
        {
            PlayerScript.instance.shopCustomer.ExitShop();
        }
    }

    private void FixedUpdate()
    {
        if (PlayerScript.instance.target && !PlayerScript.instance.target.activeSelf)
        {
            PlayerScript.instance.target = null;
        }
    }
}
