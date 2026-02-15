using UnityEngine;

public class ContinueOption : MonoBehaviour
{
    public GameObject continuePanel;
    public GameObject questionPanel;

    public void OnClickYes()
    {
        int coins = PlayerPrefs.GetInt("CoinCount", 0);
        coins -= 20;
        PlayerPrefs.SetInt("CoinCount", coins);

        continuePanel.SetActive(false);
        questionPanel.SetActive(true);
        // You can optionally resume the running here too
    }

    public void OnClickNo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}