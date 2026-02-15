using UnityEngine;
using UnityEngine.UI; 

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinFX.Play();

        
            CoinManager.instance.AddCoins(1);



            gameObject.SetActive(false);
        }
    }
}
