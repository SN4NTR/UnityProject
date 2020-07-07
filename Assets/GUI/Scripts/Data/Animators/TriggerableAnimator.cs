using UnityEngine;

public abstract class TriggerableAnimator: MonoBehaviour
{
    public abstract void TriggerAnimation();

    public abstract bool TriggerableFromCar { get; }
}
