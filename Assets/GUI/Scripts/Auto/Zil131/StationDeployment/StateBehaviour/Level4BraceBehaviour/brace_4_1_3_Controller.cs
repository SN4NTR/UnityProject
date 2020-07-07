using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brace_4_1_3_Controller : MonoBehaviour
{
    private GameObject brace;
    private LineRenderer lineRenderer;
    private Transform carabineHolder;
    private Transform hoop;

    void Start()
    {
        brace = GameObject.Find("brace_4_1_3");
        lineRenderer = brace.GetComponent<LineRenderer>();
        carabineHolder = GameObject.Find("Mast Carbine Holder 4 stage left").transform;
        hoop = GameObject.Find("left hoop.003").transform;
    }

    void Update()
    {
        lineRenderer.SetPositions(new Vector3[] { carabineHolder.position, hoop.position });
    }
}
