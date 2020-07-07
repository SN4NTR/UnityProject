using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class LAntenna : InfoModelBehaviour
{


    public GameObject laInfoWindow;
    public Text laTxt;
    public Image laImg;
    private FileStream lafs;
    private StreamReader lasr;

    public override void onRaycastClick()
    {
        Debug.Log("Test Door 3 Info Opened");
        Texture2D tex = new Texture2D(512, 512);
        tex.LoadImage(File.ReadAllBytes("Assets\\Info\\antenna_V.jpg"));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        laImg.sprite = sprite;
        lafs = new FileStream("Assets\\Info\\Antenna_V.txt", FileMode.Open);
        lasr = new StreamReader(lafs, System.Text.Encoding.Unicode);
        laTxt.text = "";
        while (lasr.Peek() >= 0)
            laTxt.text += lasr.ReadLine();
        laTxt.fontSize = 22;
        laTxt.alignment = TextAnchor.MiddleCenter;
        laInfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test Door Info Closed");
        lafs.Close();
        lasr.Close();
        laInfoWindow.SetActive(false);
    }

}
