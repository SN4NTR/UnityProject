using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public float beginTime = 8f;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > beginTime) {
            SceneManager.LoadScene(nextScene);
        }
    }
}
