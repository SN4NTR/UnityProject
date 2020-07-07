using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {

    public Text text;
    private bool enable = true;
	void Start () {
        if (!text)
        {
            enable = false;
        } else
        {
            text.enabled = false;
        }
    }
    public void SetText(string val)
    {
        if (!enable)
        {
            return;
        }
        text.text = val;
        text.enabled = true;
    }
    public void ClearText()
    {
        if(!enable)
        {
            return;
        }
        text.enabled = false;
    }
}
