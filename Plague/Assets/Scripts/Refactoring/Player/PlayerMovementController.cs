using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        if (direction.Equals(Vector3.zero))
        {
            return;
        }

        rb.velocity = direction * 5f;


    }
}
