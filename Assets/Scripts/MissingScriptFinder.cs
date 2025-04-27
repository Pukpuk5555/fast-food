using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MissingScriptFinder : MonoBehaviour
{
    [MenuItem("Tools/Find Missing Scripts in Scene")]
    static void FindMissingScriptsInScene()
    {
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        int goCount = 0, componentsCount = 0, missingCount = 0;

        foreach (GameObject go in allGameObjects)
        {
            goCount++;
            Component[] components = go.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                componentsCount++;
                if (components[i] == null)
                {
                    missingCount++;
                    Debug.LogWarning($"Missing script found on GameObject: {GetGameObjectPath(go)}", go);
                }
            }
        }

        Debug.Log($"Searched {goCount} GameObjects, {componentsCount} components, found {missingCount} missing scripts.");
    }

    private static string GetGameObjectPath(GameObject go)
    {
        string path = go.name;
        Transform current = go.transform;
        while (current.parent != null)
        {
            current = current.parent;
            path = current.name + "/" + path;
        }
        return path;
    }
}
