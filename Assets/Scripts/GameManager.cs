using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make GameManager persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one GameManager instance
        }
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before loading a new scene
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    // Call this method to toggle the pause state from anywhere
    public void TogglePause()
    {
        if (PauseMenu.GameIsPaused)
        {
            // If you have an instance of the PauseMenu, call Resume on it
            FindObjectOfType<PauseMenu>()?.Resume();
        }
        else
        {
            // Otherwise, call Pause on the PauseMenu instance
            FindObjectOfType<PauseMenu>()?.Pause();
        }
    }

    // Example usage of LoadScene within GameManager
    public void LoadMainMenu()
    {
        LoadScene("MainMenu");
    }

    public void LoadTutorial()
    {
        LoadScene("Tutorial");
    }

    public void LoadLevel1()
    {
        LoadScene("Level1");
    }
}
