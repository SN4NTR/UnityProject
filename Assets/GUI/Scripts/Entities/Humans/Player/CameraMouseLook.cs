using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMouseLook : MonoBehaviour
{
    public Text eventText;
    public FPSController FpsController;
    private Animator animator;
    private TriggerableAnimator triggerableAnimator;
    private InfoModelBehaviour infoModelBehaviour;
    private SelectionManager selectionManager;
    private InfoManager infoManager;
    private new Camera camera;
    private GameObject lookPrevGameObject;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        selectionManager = GameObject.FindObjectOfType<SelectionManager>();
        infoManager = FindObjectOfType<InfoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastEvent();
        Action();
        //Debug.Log("0");
    }

    private void RaycastEvent()
    {
        Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
        Ray ray = camera.ScreenPointToRay(point);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            TriggerAnimator(raycastHit);
            TriggerInformation(raycastHit);
            CheckAnimationOnClick(raycastHit.transform.gameObject);
            CheckInfo(raycastHit.transform.gameObject);
            CheckSelection(raycastHit.transform.gameObject);
            CheckDoor(raycastHit.transform.gameObject);
            //Debug.Log("1");
        }
        else
        {
            infoModelBehaviour = null;
            triggerableAnimator = null;
            eventText.text = string.Empty;
        }
    }

    private void CheckAnimationOnClick(GameObject gameObject)
    {
        if (Input.GetMouseButtonUp(0) && !!gameObject.GetComponent<AnimationOnClick>())
        {
            gameObject.GetComponent<AnimationOnClick>().OnClick();
        }
    }

    private void CheckDoor(GameObject gameObject)
    {
        //Debug.Log(gameObject.ToString());
        while (gameObject != null && gameObject.transform.parent != null && !gameObject.GetComponent<DoorScript>())
        {
            gameObject = gameObject.transform.parent.gameObject;
        }

        //Debug.Log(gameObject.ToString());
        if (gameObject != null && Input.GetMouseButtonUp(0) && !!gameObject.GetComponent<DoorScript>())
        {
            gameObject.GetComponent<DoorScript>().ReactToHit();
            //Debug.Log("2");
        }
    }

    private void CheckInfo(GameObject gameObject)
    {
        if (gameObject && gameObject.GetComponent<InfoOnHover>())
        {
            infoManager.SetText(gameObject.GetComponent<InfoOnHover>().InfoToDisplay);
        } else
        {
            infoManager.ClearText();
        }
    }

    private void CheckSelection(GameObject gameObject)
    {
        if (gameObject == lookPrevGameObject)
        {
            return;
        }

        if (lookPrevGameObject && lookPrevGameObject.GetComponent<HighlighOnHover>())
        {
            selectionManager.Deselect(lookPrevGameObject);
        }

        if (gameObject && gameObject.GetComponent<HighlighOnHover>())
        {
            selectionManager.Select(gameObject, gameObject.GetComponent<HighlighOnHover>().type);
        }

        lookPrevGameObject = gameObject;
    }

    private void Action()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerableAnimator != null)
        {
            triggerableAnimator.TriggerAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Q) && FpsController.IsInCar)
        {
            triggerableAnimator.TriggerAnimation();
        }

        if (Input.GetMouseButtonDown(1) && infoModelBehaviour != null)
        {
            infoModelBehaviour.InfoOpened = !infoModelBehaviour.InfoOpened;
            if (infoModelBehaviour.InfoOpened)
            {
                infoModelBehaviour.onRaycastClick();
                FpsController.StopWork();
            }
            else
            {
                infoModelBehaviour.onRaycastClose();
                FpsController.StartWork();
            }
        }
    }

    private void TriggerAnimator(RaycastHit raycastHit)
    {
        animator = raycastHit.collider.gameObject.GetComponent<Animator>();
        if (animator != null)
        {
            triggerableAnimator = animator.GetComponent<MonoBehaviour>() as TriggerableAnimator;
            if (triggerableAnimator == null)
            {
                eventText.text = "";
                return;
            }
            if (FpsController.IsInCar && !triggerableAnimator.TriggerableFromCar)
            {
                eventText.text = "";
                triggerableAnimator = null;
            }
            else if ((FpsController.IsInCar && triggerableAnimator.TriggerableFromCar) || !FpsController.IsInCar)
            {
                eventText.text = "Press E";
            }
        }
    }

    private void TriggerInformation(RaycastHit raycastHit)
    {
        var info = raycastHit.collider.GetComponent<InfoModelBehaviour>();
        if (info == null && infoModelBehaviour == null)
        {
            return;
        }
        if (info == null)
        {
            infoModelBehaviour.onRaycastLeave();
            infoModelBehaviour = null;
        }
        else
        {
            infoModelBehaviour = info;
            infoModelBehaviour.onRaycastEnter();
        }
    }
}
