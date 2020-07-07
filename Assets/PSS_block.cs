using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class PSS_block : InfoModelBehaviour
{

    public GameObject pssInfoWindow;
    public Text pssTxt;
    public Image pssImg;
    private FileStream pssfs;
    private StreamReader psssr;

    public override void onRaycastClick()
    {
        Debug.Log("Test Door 3 Info Opened");
        Texture2D tex = new Texture2D(512, 512);
        tex.LoadImage(File.ReadAllBytes("Assets\\Info\\PSS.jpg"));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        pssImg.sprite = sprite;
        pssfs = new FileStream("Assets\\Info\\PSS.txt", FileMode.Open);
        psssr = new StreamReader(pssfs, System.Text.Encoding.Unicode);
        pssTxt.text = "";
        while (psssr.Peek() >= 0)
            pssTxt.text += psssr.ReadLine();
        pssTxt.fontSize = 22;
        pssTxt.alignment = TextAnchor.MiddleCenter;
        pssInfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("Test Door Info Closed");
        pssfs.Close();
        psssr.Close();
        pssInfoWindow.SetActive(false);
    }

}
