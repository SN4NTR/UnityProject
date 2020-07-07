using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brace_1_2_2_Controller : MonoBehaviour {

    private GameObject brace;
    private LineRenderer lineRenderer;
    private Transform carabineHolder;
    private Transform hoop;

    void Start()
    {
        brace = GameObject.Find("brace_1_2_2");
        lineRenderer = brace.GetComponent<LineRenderer>();
        carabineHolder = GameObject.Find("Mast Carbine Holder 1 stage right.001").transform;
        hoop = GameObject.Find("right hoop.006").transform;
    }

    void Update()
    {
        lineRenderer.SetPositions(new Vector3[] { carabineHolder.position, hoop.position });
    }
}
