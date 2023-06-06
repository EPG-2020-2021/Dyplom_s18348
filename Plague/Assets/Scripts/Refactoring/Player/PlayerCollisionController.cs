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
            PlayerScript.instance.targets.Add(other.gameObject);
        }

        if (other.GetComponent<Shop>() != null)
        {
            PlayerScript.instance.shopCustomer.SetShop(other.GetComponent<Shop>());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (PlayerScript.instance.targets != null && PlayerScript.instance.targets.Contains(other.gameObject))
        {
            PlayerScript.instance.targets.Remove(other.gameObject);
        }

        if (other.GetComponent<Shop>() != null)
        {
            PlayerScript.instance.shopCustomer.ExitShop();
        }
    }

    private void FixedUpdate()
    {
        if (PlayerScript.instance.targets.Count >= 1)
        {
                if (!PlayerScript.instance.targets[0].activeSelf) PlayerScript.instance.targets.Remove(PlayerScript.instance.targets[0]);
            
        }
    }
}
