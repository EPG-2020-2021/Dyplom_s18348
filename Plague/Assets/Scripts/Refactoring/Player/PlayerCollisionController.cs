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

    private void OnTriggerExit(Collider other)
    {
        if (PlayerScript.instance.target.Equals(other))
        {
            PlayerScript.instance.target = null;
        }
    }
}
