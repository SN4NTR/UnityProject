using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public bool rotateLeft = true;
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = false;
    public int rotateAngle = 90;
    private Animator _animator;
    private bool rotating = false;
    private bool open = false;

    private IEnumerator Rotate()
    {
        int x = rotateX ? rotateAngle * (rotateLeft ? -1 : 1) : 0;
        int y = rotateY ? rotateAngle * (rotateLeft ? -1 : 1) : 0;
        int z = rotateZ ? rotateAngle * (rotateLeft ? -1 : 1) : 0;

        if (!open)
        {
            Debug.Log("haha");
            this.transform.Rotate(x, y, z);
            open = true;
        }
        else
        {
            Debug.Log("4");
            this.transform.Rotate(-x, -y, -z);
            open = false;
        }
        yield return new WaitForSeconds(1.5f);
    }

    public void ReactToHit()
    {
        if (!rotating)
            StartCoroutine(Rotate());
    }
}
