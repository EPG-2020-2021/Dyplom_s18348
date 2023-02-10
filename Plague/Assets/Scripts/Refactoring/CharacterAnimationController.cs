using System;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer sr;

    public CharacterAnimationController()
    {
    }

    public void MoveAnimation(float y, float x)
    {
        if (x != 0f)
        {
            this.sr.flipX = (x > 0f ? false : true);
        }
        this.animator.SetFloat("Speed", Mathf.Abs(y) + Mathf.Abs(x));
    }

    private void Start()
    {
        this.animator = base.GetComponent<Animator>();
        this.sr = base.GetComponent<SpriteRenderer>();
    }
}