using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;

    public void LoadScene()
    {
        if(!string.IsNullOrEmpty(sceneNameToLoad))
        {
            SceneManager.LoadScene(sceneNameToLoad);
            Debug.Log("Open " + sceneNameToLoad);
        }
    }
}
