using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class Wardrobe2 : InfoModelBehaviour
{

    public GameObject w2InfoWindow;
    public Text w2Txt;
    public Image w2Img;
    private FileStream w2fs;
    private StreamReader w2sr;

    public override void onRaycastClick()
    {
        Debug.Log("Test Door 2 Info Opened");
        Texture2D tex = new Texture2D(512, 512);
        tex.LoadImage(File.ReadAllBytes("Assets\\Info\\wardrobe2.jpg"));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        w2Img.sprite = sprite;
        w2fs = new FileStream("Assets\\Info\\wardrobe2.txt", FileMode.Open);
        w2sr = new StreamReader(w2fs, System.Text.Encoding.Unicode);
        w2Txt.text = "";
        while (w2sr.Peek() >= 0)
            w2Txt.text += w2sr.ReadLine();
        w2Txt.fontSize = 22;
        w2Txt.alignment = TextAnchor.MiddleCenter;
        w2InfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test Door Info Closed");
        w2fs.Close();
        w2sr.Close();
        w2InfoWindow.SetActive(false);
    }

}
