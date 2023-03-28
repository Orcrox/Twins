using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void setMovement(Vector2 input, Vector2 velocity)
    {
        if (input.x != 0)
        {
            animator.SetFloat("InputH", input.x);
        }
    }


}
