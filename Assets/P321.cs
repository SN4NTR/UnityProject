using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class P321 : InfoModelBehaviour
{

    public GameObject p321InfoWindow;
    public Text p321Txt;
    public Image p321Img;
    private FileStream p321fs;
    private StreamReader p321sr;

    public override void onRaycastClick()
    {
        Debug.Log("Test Door 3 Info Opened");
        Texture2D tex = new Texture2D(512, 512);
        tex.LoadImage(File.ReadAllBytes("Assets\\Info\\P321.jpg"));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        p321Img.sprite = sprite;
        p321fs = new FileStream("Assets\\Info\\P321.txt", FileMode.Open);
        p321sr = new StreamReader(p321fs, System.Text.Encoding.Unicode);
        p321Txt.text = "";
        while (p321sr.Peek() >= 0)
            p321Txt.text += p321sr.ReadLine();
        p321Txt.fontSize = 24;
        p321Txt.alignment = TextAnchor.MiddleCenter;
        p321InfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test Door Info Closed");
        p321fs.Close();
        p321sr.Close();
        p321InfoWindow.SetActive(false);
    }

}
