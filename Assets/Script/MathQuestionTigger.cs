using UnityEngine;

public class MathQuestionTrigger : MonoBehaviour
{
    public MathQuestionManager mathQuestionManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mathQuestionManager != null)
            {
                mathQuestionManager.ShowAdditionQuestion();
                gameObject.SetActive(false); // Disable the trigger after use
            }
            else
            {
                Debug.LogError("MathQuestionManager is not assigned in MathQuestionTrigger!");
            }
        }
    }
}