using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerColorsHandeler : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer[] layers;
    [SerializeField]
    private ColorInfo colorInfo;


    public void UpdateLayers()
    {
        Color.RGBToHSV(colorInfo.darkColor, out float H, out float S, out float V);
        Color.RGBToHSV(colorInfo.hueColor, out float endH, out float endS, out float endV);
        float val = V; //black
        float sat = S; //light
        float hue = H; //color
        //Debug.Log("dark color | hue: " + H + " | sat: " + S + " | val: " + V);
        //Debug.Log("light color | hue: " + endH + " | sat: " + endS + " | val: " + endV);

        for (int i = 0; i < layers.Length; i++)
        {
            //Debug.Log("index: "+ i + " | hue: " + hue);

            float presentage = (float)i / ((float)layers.Length - 1);
            float circularPrecentage = +Mathf.Sin(presentage * Mathf.PI);
            float cappedPrecentage = +Mathf.Min(presentage + presentage, 1);

            val = Mathf.Lerp(V, endV, cappedPrecentage);
            sat = Mathf.Lerp(S, endS, circularPrecentage);

            if ( H - endH > 0.5f)
            {
                hue = Mathf.Lerp(H, endH + 1, presentage) % 1;
            } else if ( endH - H > 0.5f)
            {
                hue = Mathf.Lerp(H + 1, endH, presentage) % 1;
            }
            else
            {
                hue = Mathf.Lerp(H, endH, presentage);
            }
            if (i == layers.Length - 1)
            {
                sat /= 4;
            }

            Color newColor = Color.HSVToRGB(hue, sat, val);
            newColor.a = colorInfo.alpha;
            layers[ (layers.Length -1) - i].color = newColor;
        }
    }
}

[System.Serializable]
public class ColorInfo { 
    public Color hueColor;
    public Color darkColor;
    public float alpha = 0.8f;
}
