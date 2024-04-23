using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial"); // Replace with your tutorial scene name
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1"); // Replace with your level 1 scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
