using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class Upp : InfoModelBehaviour
{


    public GameObject uppInfoWindow;
    public Text uppTxt;
    public Image uppImg;
    private FileStream uppfs;
    private StreamReader uppsr;

    public override void onRaycastClick()
    {
        Debug.Log("Test upp Info Opened");
        Texture2D tex = new Texture2D(512, 512);
        tex.LoadImage(File.ReadAllBytes("Assets\\Info\\ustroistvo_priemo_peredayuschee.jpg"));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        uppImg.sprite = sprite;
        uppfs = new FileStream("Assets\\Info\\ustroistvo_priemo_peredayuschee.txt", FileMode.Open);
        uppsr = new StreamReader(uppfs, System.Text.Encoding.Unicode);
        uppTxt.text = "";
        while (uppsr.Peek() >= 0)
            uppTxt.text += uppsr.ReadLine();
        uppTxt.fontSize = 22;
        uppTxt.alignment = TextAnchor.MiddleCenter;
        uppInfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test upp Info Closed");
        uppfs.Close();
        uppsr.Close();
        uppInfoWindow.SetActive(false);
    }

}
