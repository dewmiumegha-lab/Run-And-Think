using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathQuestionManager : MonoBehaviour
{
    public GameObject questionPanel;
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    public Button submitButton;
    public TextMeshProUGUI timerText;

    public GameObject continuePanel;
    public Button continueButton;
    public TextMeshProUGUI continueMessage;

    private int correctAnswer;
    private float countdownTime = 10f;
    private bool questionActive = false;
    private bool gameIsOver = false;

    void Start()
    {
        questionPanel.SetActive(false);
        continuePanel.SetActive(false);
        submitButton.onClick.AddListener(CheckAnswer);
        continueButton.onClick.AddListener(ContinueWithCoins);
    }

    void Update()
    {
        if (gameIsOver || !questionActive) return;

        // Auto-focus input field while question is active
        if (!answerInput.isFocused)
        {
            answerInput.ActivateInputField();
        }

        countdownTime -= Time.deltaTime;
        countdownTime = Mathf.Clamp(countdownTime, 0, Mathf.Infinity);
        timerText.text = "Time: " + Mathf.CeilToInt(countdownTime).ToString();

        if (countdownTime <= 0)
        {
            questionActive = false;

            // End game immediately if not enough coins
            if (CoinManager.instance != null && CoinManager.instance.GetCoins() >= 20)
            {
                HandleIncorrectAnswer(); // Offer to continue
            }
            else
            {
                GameOver(); // End game
            }
        }

        // Check if Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    public void ShowAdditionQuestion()
    {
        if (gameIsOver) return;

        int a = Random.Range(1, 51);
        int b = Random.Range(1, 51);
        correctAnswer = a + b;

        questionText.text = $"What is {a} + {b}?";
        answerInput.text = "";
        countdownTime = 10f;
        questionActive = true;

        questionPanel.SetActive(true);
        continuePanel.SetActive(false);

        answerInput.ActivateInputField();
    }

    public void CheckAnswer()
    {
        if (!questionActive || gameIsOver) return;

        int playerAnswer;
        bool isNumber = int.TryParse(answerInput.text, out playerAnswer);

        if (isNumber && playerAnswer == correctAnswer)
        {
            if (CoinManager.instance != null)
            {
                CoinManager.instance.AddCoins(10);
            }
            else
            {
                Debug.LogError("CoinManager instance is null!");
            }

            questionActive = false;
            questionPanel.SetActive(false);
        }
        else
        {
            questionActive = false;
            HandleIncorrectAnswer();
        }
    }

    void HandleIncorrectAnswer()
    {
        questionPanel.SetActive(false);

        if (CoinManager.instance != null && CoinManager.instance.GetCoins() >= 20)
        {
            continuePanel.SetActive(true);
            continueMessage.text = "Incorrect! Spend 20 coins to try again?";
        }
        else
        {
            GameOver();
        }
    }

    void ContinueWithCoins()
    {
        if (CoinManager.instance != null && CoinManager.instance.GetCoins() >= 20)
        {
            CoinManager.instance.RemoveCoins(20);

            answerInput.text = "";
            continuePanel.SetActive(false);
            questionPanel.SetActive(true);
            questionActive = true;

            countdownTime = 10f;
            answerInput.ActivateInputField();
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameIsOver = true;
        questionActive = false;

        if (CoinManager.instance != null)
        {
            PlayerPrefs.SetInt("FinalCoins", CoinManager.instance.GetCoins());
        }

        PlayerPrefs.SetInt("LastPlayedLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOver");
    }
}
