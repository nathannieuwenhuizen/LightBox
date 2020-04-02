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
        if (GUILayout.Button("Apply Settings"))
        {
            if (myScript != null)
            {
                myScript.UpdateLayers();
            }
        }

    }
}
