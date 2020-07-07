using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneDimming : MonoBehaviour
{
    public Image dimImage;
    public float beginTime = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > beginTime) {
            var color = dimImage.color;
            color.a = Math.Min(Time.timeSinceLevelLoad - beginTime, 1f);
            dimImage.color = color;
        }
    }
}
