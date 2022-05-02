using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEffect : MonoBehaviour
{

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void InitializeAnimator()
    {
        animator.Play("healing");
    }

}
