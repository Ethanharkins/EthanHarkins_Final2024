using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject overlayUI; // Assign your overlay UI GameObject in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() // Make sure this is public
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume game time
        GameIsPaused = false;
        overlayUI.SetActive(true); // Reactivate the overlay UI
    }

    public void Pause() // Make sure this is public
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause game time
        GameIsPaused = true;
        overlayUI.SetActive(false); // Deactivate the overlay UI
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure game time is normalized before loading the main menu
        SceneManager.LoadScene("MainMenu"); // Load the scene named "MainMenu"
    }
}
