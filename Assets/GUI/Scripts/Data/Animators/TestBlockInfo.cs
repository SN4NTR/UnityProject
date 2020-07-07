using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlockInfo : InfoModelBehaviour {
    public override void onRaycastClick()
    {
        Debug.Log("Test Door Info Opened");
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test Door Info Closed");
    }
}
