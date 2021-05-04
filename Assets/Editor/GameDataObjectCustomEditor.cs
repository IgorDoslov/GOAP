using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;


public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceID, int line)
    {
        ResourceData obj = EditorUtility.InstanceIDToObject(instanceID) as ResourceData;
        if (obj != null)
        {
            GameDataObjectEditorWindow.Open(obj);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(ResourceData))]
public class GameDataObjectCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameDataObjectEditorWindow.Open((ResourceData)target);
    }
}
