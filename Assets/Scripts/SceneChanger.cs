using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;

    [SerializeField] private GameObject pauseUI;
    private bool isPause = false;

    public void LoadScene()
    {
        if(!string.IsNullOrEmpty(sceneNameToLoad))
        {
            SceneManager.LoadScene(sceneNameToLoad);
            Debug.Log("Open " + sceneNameToLoad);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game is Pause.");
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if(!isPause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
        }
    }

    public void ResumeGame()
    {
        if(isPause)
        {
            Debug.Log("Resuming Game...");
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
            isPause = false;
        }
    }
}
