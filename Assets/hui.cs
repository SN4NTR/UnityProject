using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class hui : InfoModelBehaviour {

    public GameObject huyInfoWindow;
    public Text huyTxt;
    public Image huyImg;
    private FileStream huyfs;
    private StreamReader huysr;

    public override void onRaycastClick()
    {
        Debug.Log("Test Huy Info Opened");
        Texture2D tex = new Texture2D(512, 512);
        tex.LoadImage(File.ReadAllBytes("Assets\\Info\\antennaFalos.jpg"));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        huyImg.sprite = sprite;
        huyfs = new FileStream("Assets\\Info\\AntennaFalos.txt", FileMode.Open);
        huysr = new StreamReader(huyfs, System.Text.Encoding.Unicode);
        huyTxt.text = "";
        while (huysr.Peek() >= 0)
            huyTxt.text += huysr.ReadLine();
        huyTxt.fontSize = 24;
        huyTxt.alignment = TextAnchor.MiddleCenter;
        huyInfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test Huy Put");
        huyfs.Close();
        huysr.Close();
        huyInfoWindow.SetActive(false);
    }

}
