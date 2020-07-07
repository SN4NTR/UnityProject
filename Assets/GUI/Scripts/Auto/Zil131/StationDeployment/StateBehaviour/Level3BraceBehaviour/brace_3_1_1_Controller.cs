using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brace_3_1_1_Controller : MonoBehaviour {

    private GameObject brace;
    private LineRenderer lineRenderer;
    private Transform carabineHolder;
    private Transform hoop;

    void Start()
    {
        brace = GameObject.Find("brace_3_1_1");
        lineRenderer = brace.GetComponent<LineRenderer>();
        carabineHolder = GameObject.Find("Mast Carbine Holder 3 stage left").transform;
        hoop = GameObject.Find("right hoop.010").transform;
    }

    void Update()
    {
        lineRenderer.SetPositions(new Vector3[] { carabineHolder.position, hoop.position });
    }
}
