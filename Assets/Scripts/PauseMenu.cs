using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; // Assign this in the Inspector

    private PlayerInput playerInput;
    private InputAction pauseAction;

    private void Awake()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        pauseAction = playerInput.actions["Pause"]; // Make sure this action is correctly set up in your Input Actions asset
    }

    private void OnEnable()
    {
        pauseAction.performed += _ => TogglePause();
    }

    private void OnDisable()
    {
        pauseAction.performed -= _ => TogglePause();
    }

    public void TogglePause()
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

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerInput.enabled = false; // Optionally disable player input while the game is paused
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerInput.enabled = true; // Re-enable player input when the game resumes
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure time scale is reset
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
