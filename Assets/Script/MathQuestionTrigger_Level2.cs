using UnityEngine;

public class MathQuestionTrigger_Level2 : MonoBehaviour
{
    public MathQuestionManager_Level2 mathQuestionManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mathQuestionManager != null)
            {
                mathQuestionManager.ShowSubtractionQuestion();
                gameObject.SetActive(false); // Disable trigger after use
            }
            else
            {
                Debug.LogError("MathQuestionManager_Subtraction is not assigned in MathQuestionTrigger_Level2!");
            }
        }
    }
}
