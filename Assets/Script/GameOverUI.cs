using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        int finalCoins = PlayerPrefs.GetInt("FinalCoins", 0);
        coinText.text = "Your Coins: " + finalCoins.ToString();
    }

    public void RetryLevel()
    {
        int lastLevel = PlayerPrefs.GetInt("LastPlayedLevel", 1); // default Level 1 if none saved
        SceneManager.LoadScene(lastLevel);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
