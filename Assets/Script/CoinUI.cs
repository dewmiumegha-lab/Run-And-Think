using UnityEngine;
using TMPro;

public class CoinUIUpdater : MonoBehaviour
{
    void Start()
    {
        
        TextMeshProUGUI coinText = GameObject.FindWithTag("CoinText")?.GetComponent<TextMeshProUGUI>();

       
        if (CoinManager.instance != null && coinText != null)
        {
            CoinManager.instance.coinText = coinText;
            CoinManager.instance.UpdateCoinUI(); 
        }
    }
}
