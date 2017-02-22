using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour {

    public bool isFadingOut;
    public Texture2D fadeImage;
    public float fadeSpeed = .2f;
    public int drawDepth; 
    private float alpha = 1.0f;
    private int fadeDir = -1;


   void Start()
    {

    }
    void OnGUI()
    {
        if (isFadingOut)
        {
            alpha -= fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            Color thisAlpha = GUI.color;
            thisAlpha.a = alpha;
            GUI.color = thisAlpha;

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeImage);
        }

    }

}
