using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerColorsHandeler : MonoBehaviour
{
    [Header("GeneratedColors")]
    [SerializeField]
    private Color[] colors;

    [Header("Info")]

    [SerializeField]
    private GameObject[] layers;
    [SerializeField]
    private ColorInfo colorInfo;

    public void GenerateColorPallet()
    {
        Debug.Log("GenrateColor pallet");
        Color.RGBToHSV(colorInfo.darkColor, out float H, out float S, out float V);
        Color.RGBToHSV(colorInfo.hueColor, out float endH, out float endS, out float endV);
        float val = V; //black
        float sat = S; //light
        float hue = H; //color

        List<Color> list = new List<Color>();

        for (int i = 0; i < layers.Length; i++)
        {

            float presentage = (float)i / ((float)layers.Length - 1);
            float circularPrecentage = +Mathf.Sin(presentage * Mathf.PI);
            float cappedPrecentage = +Mathf.Min(presentage + presentage, 1);

            val = Mathf.Lerp(V, endV, presentage);
            sat = Mathf.Lerp(S, endS, presentage);

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
            //setColorForLayer(layers[(layers.Length - 1) - i], newColor, (layers.Length - 1) - i);
            list.Add(newColor);
        }
        colors = list.ToArray();

        //updateLayers();
    }

    public void setColorForLayer(GameObject layer, Color color, int orderIndex)
    {
        foreach(SpriteRenderer sr in layer.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.color = color;
            sr.sortingOrder = orderIndex;
        }
    }

    public void updateLayers()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            if (i < colors.Length)
            {
                setColorForLayer(layers[(layers.Length - 1) - i], colors[i], (layers.Length - 1) - i);
            }
        }
    }
}

[System.Serializable]
public class ColorInfo { 
    public Color hueColor;
    public Color darkColor;
    public float alpha = 0.8f;
    public float minValue;
}
