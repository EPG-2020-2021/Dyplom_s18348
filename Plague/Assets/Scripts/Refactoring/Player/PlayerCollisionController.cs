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
        print("triggering with " + other.name);
        PlayerScript.instance.target = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        print("triggering out of " + other.name);
        if (PlayerScript.instance.target.Equals(other.gameObject))
        {
            PlayerScript.instance.target = null;
        }
    }
}
