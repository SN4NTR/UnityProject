using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastLeftRotateCounterClockwiseBehaviour : StateMachineBehaviour
{
    private int NEED_STAGE_FOR_BRACES_APPEARING = 12;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var objects = new List<string>() { "brace_4_1_1", "brace_4_1_2", "brace_4_1_3",
                                           "brace_3_1_1", "brace_3_1_2", "brace_3_1_3",
                                           "brace_2_1_1", "brace_2_1_2", "brace_2_1_3",
                                           "brace_1_1_3", "brace_1_1_1", "brace_1_1_2" };

        var currentStage = animator.GetInteger("CurrentStage");

        foreach (var objectName in objects)
        {
            GameObject.Find(objectName).GetComponent<LineRenderer>().enabled = currentStage >= NEED_STAGE_FOR_BRACES_APPEARING;
        }
    }
}
