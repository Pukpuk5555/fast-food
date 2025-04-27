using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;

    [SerializeField] private GameObject pauseUI;
    private bool isPause = false;

    public static SceneChanger instance;

    public void LoadScene()
    {
        if(!string.IsNullOrEmpty(sceneNameToLoad))
        {
            Time.timeScale = 1f;
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

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
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

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is Quit.");
    }

    public void LevelScene()
    {
        SceneManager.LoadScene(3);
    }
}
