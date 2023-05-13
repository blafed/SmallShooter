
using UnityEngine;
using UnityEditor;
public static class CustomActions
{
    [MenuItem("Custom/Set All Sprites to Point filter mode")]
    public static void ConvertAllToPointFilter()
    {
        if (EditorUtility.DisplayDialog(
            "ConvertAllToPointFilter",
            "Are you sure to procceed. ACTION CAN NOT BE UNDONE",
            "Continue",
            "Cancel"
        ))
        {
            foreach (string guid in AssetDatabase.FindAssets("t:texture", null))
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                var importer = AssetImporter.GetAtPath(path) as TextureImporter;
                importer.filterMode = FilterMode.Point;
                importer.SaveAndReimport();
            }
            AssetDatabase.Refresh();
        }
    }
}