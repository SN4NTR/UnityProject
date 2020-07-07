using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InfoModelBehaviour : MonoBehaviour {
    protected float _colorDiffBlue = 0.3f;
    protected float _colorDiffRed = 0.3f;
    protected float _colorDiffGreen = 0.3f;
    private bool IsEntered;
    public bool InfoOpened { get; set; }

    private void highlightObject(float colorDiffBlue, float colorDiffRed, float colorDiffGreen)
    {
        var objects = GetComponentsInChildren<Renderer>();

        for (var i = 0; i < objects.Length; i++)
        {
            var obj = objects[i];
            for (var j = 0; j < obj.materials.Length; j++)
            {
                var objectColor = obj.materials[j].color;
                objectColor.b += colorDiffBlue;
                objectColor.r += colorDiffRed;
                objectColor.g += colorDiffGreen;
                obj.materials[j].color = objectColor;
            }
        }
    }

    public virtual void onRaycastEnter()
    {
        if (IsEntered) return;
        IsEntered = true;
        highlightObject(_colorDiffBlue, _colorDiffRed, _colorDiffGreen);
    }

    public virtual void onRaycastLeave()
    {
        if (!IsEntered) return;
        IsEntered = false;
        highlightObject(-_colorDiffBlue, -_colorDiffRed, -_colorDiffGreen);
    }

    public abstract void onRaycastClick();
    public abstract void onRaycastClose();
}
