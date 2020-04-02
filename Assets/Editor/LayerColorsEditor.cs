using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LayerColorsHandeler))]
public class LayerColorsEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
        LayerColorsHandeler myScript = (LayerColorsHandeler)target;
        if (GUILayout.Button("Generate Colors (will overide the colors value)"))
        {
            if (myScript != null)
            {
                myScript.GenerateColorPallet();
            }
        }
        myScript.updateLayers();

    }
    
}
