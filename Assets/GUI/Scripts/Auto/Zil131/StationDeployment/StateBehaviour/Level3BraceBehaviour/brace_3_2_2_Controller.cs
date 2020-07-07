using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brace_3_2_2_Controller : MonoBehaviour {

    private GameObject brace;
    private LineRenderer lineRenderer;
    private Transform carabineHolder;
    private Transform hoop;

    void Start()
    {
        brace = GameObject.Find("brace_3_2_2");
        lineRenderer = brace.GetComponent<LineRenderer>();
        carabineHolder = GameObject.Find("Mast Carbine Holder 3 stage right").transform;
        hoop = GameObject.Find("right hoop.009").transform;
    }

    void Update()
    {
        lineRenderer.SetPositions(new Vector3[] { carabineHolder.position, hoop.position });
    }
}
