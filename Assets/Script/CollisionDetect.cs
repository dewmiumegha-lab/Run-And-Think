using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject playerAnim;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fadeOut;

    void OnTriggerEnter(Collider other)
    {
        // Optional: Check if collider is obstacle/player or whatever triggers collision
        // if (other.CompareTag("Obstacle")) 
        // {
        StartCoroutine(CollisionEnd());
        // }
    }

    IEnumerator CollisionEnd()
    {
        collisionFX.Play();

        // Disable player movement and play animations
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        playerAnim.GetComponent<Animator>().Play("Stumble Backwards");
        mainCam.GetComponent<Animator>().Play("CollisionCam");

        yield return new WaitForSeconds(3);

        fadeOut.SetActive(true);

        yield return new WaitForSeconds(3);

        // Save current level index for retry
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastPlayedLevel", currentLevel);

        // Load GameOver scene by name (make sure this scene exists and added to Build Settings)
        SceneManager.LoadScene("GameOver");
    }
}
