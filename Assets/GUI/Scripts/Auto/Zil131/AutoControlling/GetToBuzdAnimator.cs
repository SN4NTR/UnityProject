using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetToBuzdAnimator : TriggerableAnimator
{
    public FPSController fpsController;
    private Animator animator;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TriggerAnimation()
    {
        animator = fpsController.GetComponent<Animator>();
        if (animator == null)
        {
            return;
        }
        StartCoroutine(AnimateGetToBuzdProcess());
    }

    public override bool TriggerableFromCar
    {
        get { return false; } 
    }

    private IEnumerator AnimateGetToBuzdProcess()
    {
        animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        animator.Play("GetToBuzdAnimation");
        yield return new WaitForSeconds(1);
        animator.cullingMode = AnimatorCullingMode.CullCompletely;
    }
}
