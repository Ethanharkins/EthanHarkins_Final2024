using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject winScreen; // Reference to the win screen UI
    public GameObject pauseMenu; // Reference to the pause menu UI

    private bool gameIsPaused = false;
    private PlayerInput playerInput;
    private InputAction pauseAction;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make GameManager persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        pauseAction = playerInput.actions["Pause"];
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
        if (gameIsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0f; // Pause the game
        if (pauseMenu != null)
            pauseMenu.SetActive(true);
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f; // Resume the game
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
        Debug.Log("Game Resumed");
    }

    public void PlayerWon()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
        Time.timeScale = 0f; // Stops the game time
        Debug.Log("Player has won the game!");
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // Ensure time scale is reset before loading a new scene
        SceneManager.LoadScene(sceneName);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        LoadScene("MainMenu"); // Update "MainMenu" with the actual scene name for your main menu
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
