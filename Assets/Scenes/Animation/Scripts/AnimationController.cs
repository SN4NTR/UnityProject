using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private const string IS_ANIMATING_VARIABLE_NAME = "isAnimating";

    private Animator animator;
    private bool isAnimating = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAnimating)
        {
            StartAnimation();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isAnimating)
        {
            StopAnimation();
        }
    }

    private void StartAnimation()
    {
        animator.SetBool(IS_ANIMATING_VARIABLE_NAME, true);
        isAnimating = true;
    }

    private void StopAnimation()
    {
        animator.SetBool("isAnimating", false);
        isAnimating = false;
    }
}
