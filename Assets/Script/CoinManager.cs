using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int currentCoins = 0;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinUI();
    }

    public void RemoveCoins(int amount)
    {
        currentCoins -= amount;
        if (currentCoins < 0)
            currentCoins = 0;
        UpdateCoinUI();
    }

    public void SetCoins(int amount)
    {
        currentCoins = amount;
        UpdateCoinUI();
    }

    public int GetCoins()
    {
        return currentCoins;
    }

    public void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + currentCoins.ToString();
        }
    }
}
