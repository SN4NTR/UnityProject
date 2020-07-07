using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DeploymentController : MonoBehaviour
{
    public Text deploymentStageText;
    public Text timeForNextDeploymentStageText;

    private static readonly string DEPLOYMENT_TAG = "Deployment";
    private static readonly string CURRENT_STAGE = "CurrentStage";

    private static readonly int MAX_STAGE = 20; //can't be 19, only less (or max_stage + 1)
    private static readonly int MIN_STAGE = 0;

    private static readonly KeyCode PREV_STAGE_BUTTON = KeyCode.Alpha1;
    private static readonly KeyCode NEXT_STAGE_BUTTON = KeyCode.Alpha2;

    private int currentStage;
    private List<Animator> animators;

    private bool isCanUpdateDeploymentStage = true;
    private float timeAfterDeploymentStageUpdating = 0;
    private float TIME_BETWEEN_DEPLOYMENT_STAGE_UPDATING = 0.05f;

    void Start()
    {
        currentStage = MIN_STAGE;

        var getGO = GameObject.FindGameObjectsWithTag(DEPLOYMENT_TAG);

        animators = (new List<GameObject>(getGO))
            .Select(obj =>
            {
                if (obj == null)
                    print(obj.gameObject.name);
                return obj.GetComponent<Animator>();
            }).ToList();
    }

    void Update()
    {
        timeAfterDeploymentStageUpdating += Time.deltaTime;

        var timeRemain = TIME_BETWEEN_DEPLOYMENT_STAGE_UPDATING - timeAfterDeploymentStageUpdating;
       /* timeForNextDeploymentStageText.text = string.Format("время до следующего этапа: {0:0.##}", timeRemain < 0 ? 0 : timeRemain);*/

        if (timeAfterDeploymentStageUpdating >= TIME_BETWEEN_DEPLOYMENT_STAGE_UPDATING)
        {
            isCanUpdateDeploymentStage = true;
        }

        int newStage = currentStage;

        if (isCanUpdateDeploymentStage)
        {
/*            if (Input.GetKeyUp(NEXT_STAGE_BUTTON))
            {*/
                newStage = GetNextStage();
/*            }
            else if (Input.GetKeyUp(PREV_STAGE_BUTTON))
            {
                newStage = GetPrevStage();
            }*/
        }

        if (currentStage != newStage)
        {
            currentStage = newStage;
            SetCurrentStageForAnimator(currentStage);

            //deploymentStageText.text = string.Format("Current deployment stage: {0}", currentStage);

            isCanUpdateDeploymentStage = false;
            timeAfterDeploymentStageUpdating = 0;
        }
    }

    void SetBoolForAnimators(string name, bool value)
    {
        foreach (var animator in animators)
        {
            animator.SetBool(name, value);
        }
    }

    int GetPrevStage()
    {
        return currentStage > MIN_STAGE ? currentStage - 1 : currentStage;
    }

    int GetNextStage()
    {
        return currentStage < MAX_STAGE ? currentStage + 1 : currentStage;
    }

    void SetCurrentStageForAnimator(int stage)
    {
        foreach (var animator in animators)
        {
            animator.SetInteger(CURRENT_STAGE, stage);
            animator.speed = 1000;
        }
    }
}
