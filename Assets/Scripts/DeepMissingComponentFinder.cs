using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class DeepMissingComponentFinder : MonoBehaviour
{
    [MenuItem("Tools/Find Deep Missing Components")]
    static void FindDeepMissingComponents()
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        int missingComponentsCount = 0;

        foreach (GameObject go in gameObjects)
        {
            SerializedObject so = new SerializedObject(go);
            SerializedProperty prop = so.FindProperty("m_Component");

            int propertyIndex = 0;
            if (prop != null && prop.isArray)
            {
                foreach (SerializedProperty component in prop)
                {
                    if (component.FindPropertyRelative("component").objectReferenceValue == null)
                    {
                        Debug.LogWarning($"Missing Component in: {GetGameObjectPath(go)} (Slot {propertyIndex})", go);
                        missingComponentsCount++;
                    }
                    propertyIndex++;
                }
            }
        }

        Debug.Log($"Found {missingComponentsCount} missing components.");
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
