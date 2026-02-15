using UnityEngine;

public class MathQuestionTrigger_Level3 : MonoBehaviour
{
    public MathQuestionManager_Level3 mathQuestionManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mathQuestionManager != null)
            {
                mathQuestionManager.ShowMultiplicationQuestion();
                gameObject.SetActive(false); // Disable trigger after use
            }
            else
            {
                Debug.LogError("MathQuestionManager_Level3 is not assigned!");
            }
        }
    }
}
