using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator
{
    private Animator animator;

    public PlayerAnimator(Animator anim)
    {
        animator = anim;
    }
   
    public void StartGame() 
    {
        animator.SetTrigger("StartGame");
    }


    public void Death() 
    {
        animator.SetTrigger("Death");
    }
}
