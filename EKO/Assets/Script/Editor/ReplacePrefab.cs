using UnityEditor;
using UnityEngine;

public class ReplaceWithPrefab : EditorWindow
{
    public GameObject prefab;
    public string tagToReplace;

    [MenuItem("Tools/Replace Objects with Prefab")]
    public static void ShowWindow()
    {
        GetWindow<ReplaceWithPrefab>("Replace Objects with Prefab");
    }

    private void OnGUI()
    {
        GUILayout.Label("Replace Objects with Prefab", EditorStyles.boldLabel);
        prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false);
        tagToReplace = EditorGUILayout.TextField("Tag to Replace", tagToReplace);

        if (GUILayout.Button("Replace"))
        {
            if (prefab != null && !string.IsNullOrEmpty(tagToReplace))
            {
                ReplaceObjects();
            }
            else
            {
                Debug.LogError("Prefab and Tag must be set.");
            }
        }
    }

    private void ReplaceObjects()
    {
        GameObject[] objectsToReplace = GameObject.FindGameObjectsWithTag(tagToReplace);

        foreach (GameObject obj in objectsToReplace)
        {
            Vector3 position = obj.transform.position;
            Quaternion rotation = obj.transform.rotation;
            Transform parent = obj.transform.parent;

            GameObject newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            newObject.transform.position = position;
            newObject.transform.rotation = rotation;
            newObject.transform.parent = parent;

            Undo.RegisterCreatedObjectUndo(newObject, "Replace Object with Prefab");
            Undo.DestroyObjectImmediate(obj);
        }
    }
}