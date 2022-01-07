using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;

    private float speed; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        RefreshSpeed();
        PlayerScript.instance.playerStats.GetStat(StatKey.Speed).onValueChange += RefreshSpeed;

    }

    private void RefreshSpeed()
    {
        speed = PlayerScript.instance.playerStats.GetStat(StatKey.Speed).value;
    }

    public void Move(Vector3 direction)
    {
        //print("Move");
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        if (direction.Equals(Vector3.zero))
        {
            return;
        }
        
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
    }
}
