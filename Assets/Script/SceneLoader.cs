using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartGame()
    {
        // Just load level 1 at start game (or whatever starting level)
        SceneManager.LoadScene(1);
    }

    public void RetryLevel()
    {
        // Load last played level saved in PlayerPrefs, default to level 1 if not found
        int lastLevel = PlayerPrefs.GetInt("LastPlayedLevel", 1);
        SceneManager.LoadScene(lastLevel);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
