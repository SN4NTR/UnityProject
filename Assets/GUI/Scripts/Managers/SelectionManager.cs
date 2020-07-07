using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    public const int INFO = 0;
    public const int ACTION = 1;
    public const int DANGER = 2;
    
    private Outline GetOrCreateOutline(GameObject gameObject)
    {
       
        if (!gameObject.GetComponent<Outline>())
        {
            gameObject.AddComponent<Outline>();
        }
        return gameObject.GetComponent<Outline>();
    }
    public void Select(GameObject gameObject, int type=SelectionManager.DANGER)
    {
        Outline outline = GetOrCreateOutline(gameObject);
        outline.color = type;
        outline.enabled = true;
    }
    public void Deselect(GameObject gameObject)
    {
        GetOrCreateOutline(gameObject).enabled = false;
    }
}
