using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;


    private void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void MoveAnimation(float y, float x)
    {
        if (x != 0) sr.flipX = x > 0 ? false : true;
        animator.SetFloat("Speed", Mathf.Abs(y) + Mathf.Abs(x));
    }
}
