using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject overlayUI; // Assign your overlay UI GameObject in the Inspector

    void Update()
    {
        // The pause functionality has been moved to the StarterAssetsInputs script.
        // This Update method can be used for additional pause menu related updates if needed.
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume game time
        GameIsPaused = false;
        if (overlayUI != null)
        {
            overlayUI.SetActive(true); // Reactivate the overlay UI if it exists
        }
    }
    public void TogglePause()
    {
        Debug.Log("Toggle pause called");
        if (PauseMenu.GameIsPaused)
        {
            FindObjectOfType<PauseMenu>().Resume();
        }
        else
        {
            FindObjectOfType<PauseMenu>().Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause game time
        GameIsPaused = true;
        if (overlayUI != null)
        {
            overlayUI.SetActive(false); // Deactivate the overlay UI if it exists
        }
    }

    public void LoadMainMenu()
    {
        Resume(); // Ensure the game is unpaused before switching scenes
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}
