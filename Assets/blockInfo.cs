using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Resources;
using System.Reflection;
using System.IO;

public class blockInfo : InfoModelBehaviour
{
    public GameObject InfoWindow;
    public Text Txt;
    public Image Img;
    public string TextPath;
    public string ImgPath;
    public int FontSize = 20;
    private FileStream fs;
    private StreamReader sr;

    public override void onRaycastClick()
    {
        Debug.Log("block Info Opened");
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(File.ReadAllBytes(ImgPath));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        Img.sprite = sprite;
        Debug.Log("tex width: " + tex.width.ToString() + " tex height: " + tex.height.ToString());

        const int maxWidth = 650;
        const int maxHeight = 700;

        float imgWidth = tex.width;
        float imgHeight = tex.height;

        if (imgWidth > maxWidth)
        {
            float ratio = (float)maxWidth / (float)imgWidth;
            imgWidth *= ratio;
            imgHeight *= ratio;
        }
        if (imgHeight > maxHeight)
        {
            float ratio = (float)maxHeight / (float)imgHeight;
            imgWidth *= ratio;
            imgHeight *= ratio;
        }

        Debug.Log("tex width: " + imgWidth.ToString() + " tex height: " + imgHeight.ToString());

        Img.rectTransform.sizeDelta = new Vector2(imgWidth, imgHeight);
        fs = new FileStream(TextPath, FileMode.Open);
        sr = new StreamReader(fs, System.Text.Encoding.UTF8);
        Txt.text = "";
        while (sr.Peek() >= 0)
        {
            string read = sr.ReadLine();
            Debug.Log(read);
            Txt.text += read + "\n";
        }
        Txt.fontSize = FontSize;
        Txt.alignment = TextAnchor.MiddleCenter;
        InfoWindow.SetActive(true);
    }

    public override void onRaycastClose()
    {
        Debug.Log("block Info Opened");
        fs.Close();
        sr.Close();
        InfoWindow.SetActive(false);
        Img.rectTransform.sizeDelta = new Vector2(639, 651);
    }
}
