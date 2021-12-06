using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float moveSpeed = 5f;
    float move;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        sr.flipX = movement.x >= 0 ? false : true;

        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(movement.y) + Mathf.Abs(movement.x));
    }

    void FixedUpdate()
    {
        move = Mathf.Abs(movement.x * moveSpeed) + Mathf.Abs(movement.y * moveSpeed);
        //animator.SetFloat("Speed", move);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
