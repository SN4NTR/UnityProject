using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnClick : MonoBehaviour {
    private static string TRIGGER_ID = "activator";
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void OnClick()
    {
        _animator.SetBool(TRIGGER_ID, !_animator.GetBool(TRIGGER_ID));
    }	
}
