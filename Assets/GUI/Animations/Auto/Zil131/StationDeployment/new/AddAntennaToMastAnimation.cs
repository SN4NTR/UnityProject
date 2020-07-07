using UnityEngine;

public class AddAntennaToMastAnimation : MonoBehaviour
{
    public GameObject Antenna;
    public GameObject MastStage;
    public int AnimationStateForAddingAntenna;

    private Transform _antennaTransform;
    private Transform _previousAntennaParentTransform;
    private Animator _mastAnimator;
    private Animator _antennaAnimator;
    private int _animationState;
    private bool _antennaAttachedToMast;

    void Start()
    {
        _antennaTransform = Antenna.transform;
        _previousAntennaParentTransform = _antennaTransform.parent.gameObject.transform;
        _mastAnimator = GetComponent<Animator>();
        _antennaAnimator = _antennaTransform.GetComponent<Animator>();
        _antennaAttachedToMast = false;
    }

    void Update()
    {
        GetAnimationState();
        if (IsStartingMastLiftAnimation())
            AddAntennaToMast();
        if (IsEndingMastLoweringAnimation())
            RemoveAntennaFromMast();
    }

    private void GetAnimationState()
    {
        var stateName = _mastAnimator.parameters[0].name;
        _animationState = _mastAnimator.GetInteger(stateName);
    }

    private bool IsStartingMastLiftAnimation()
    {
        return _animationState == AnimationStateForAddingAntenna && !_antennaAttachedToMast;
    }

    private void AddAntennaToMast()
    {
        _antennaAttachedToMast = true;
        _antennaTransform.parent = MastStage.transform;
        _antennaAnimator.enabled = false;
    }

    private bool IsEndingMastLoweringAnimation()
    {
        return _animationState == AnimationStateForAddingAntenna - 2 && _antennaAttachedToMast;
    }

    private void RemoveAntennaFromMast()
    {
        _antennaAttachedToMast = false;
        _antennaTransform.parent = _previousAntennaParentTransform;
        _antennaAnimator.enabled = true;
    }
}