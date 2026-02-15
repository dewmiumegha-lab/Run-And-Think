using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadAdditionLevel()
    {
        SceneManager.LoadScene("Level1"); 
    }

    public void LoadSubtractionLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadMultiplicationLevel()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LoadDivisionLevel()
    {
        SceneManager.LoadScene("Level4");
    }
}