using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class Wardrobe1 : InfoModelBehaviour {

    public GameObject w1InfoWindow;
    public Text w1Txt;
    public Image w1Img;
    private FileStream w1fs;
    private StreamReader w1sr;

    public override void onRaycastClick()
    {
        Debug.Log("Test Door 2 Info Opened");
        Texture2D tex = new Texture2D(512, 512);
        tex.LoadImage(File.ReadAllBytes("Assets\\Info\\wardrobe1.jpg"));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        w1Img.sprite = sprite;
        w1fs = new FileStream("Assets\\Info\\wardrobe1.txt", FileMode.Open);
        w1sr = new StreamReader(w1fs, System.Text.Encoding.Unicode);
        w1Txt.text = "";
        while (w1sr.Peek() >= 0)
            w1Txt.text += w1sr.ReadLine();
        w1Txt.fontSize = 22;
        w1Txt.alignment = TextAnchor.MiddleCenter;
        w1InfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test Door Info Closed");
        w1fs.Close();
        w1sr.Close();
        w1InfoWindow.SetActive(false);
    }

}
