using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Boolean isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAnimating)
        {
            animator.SetBool("isAnimating", true);
            isAnimating = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isAnimating)
        {
            animator.SetBool("isAnimating", false);
            isAnimating = false;
        }
    }
}
