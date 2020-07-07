using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class Wardrobe3 : InfoModelBehaviour
{

    public GameObject w3InfoWindow;
    public Text w3Txt;
    public Image w3Img;
    private FileStream w3fs;
    private StreamReader w3sr;

    public override void onRaycastClick()
    {
        Debug.Log("Test Door 3 Info Opened");
        Texture2D tex = new Texture2D(512, 512);
        tex.LoadImage(File.ReadAllBytes("Assets\\Info\\wardrobe3.jpg"));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        w3Img.sprite = sprite;
        w3fs = new FileStream("Assets\\Info\\wardrobe3.txt", FileMode.Open);
        w3sr = new StreamReader(w3fs, System.Text.Encoding.Unicode);
        w3Txt.text = "";
        while (w3sr.Peek() >= 0)
            w3Txt.text += w3sr.ReadLine();
        w3Txt.fontSize = 20;
        w3Txt.alignment = TextAnchor.MiddleCenter;
        w3InfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test Door Info Closed");
        w3fs.Close();
        w3sr.Close();
        w3InfoWindow.SetActive(false);
    }

}
