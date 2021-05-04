using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameDataObjectEditorWindow : EditorWindow
{
    public static void Open(ResourceData dataObject)
    {
        GameDataObjectEditorWindow window = GetWindow<GameDataObjectEditorWindow>("Game Data Editor");
    }
}
