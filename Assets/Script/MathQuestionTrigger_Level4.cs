using UnityEngine;

public class MathQuestionTrigger_Level4 : MonoBehaviour
{
    public MathQuestionManager_Level4 mathQuestionManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mathQuestionManager != null)
            {
                mathQuestionManager.ShowDivisionQuestion();
                gameObject.SetActive(false); // Disable trigger after use
            }
            else
            {
                Debug.LogError("MathQuestionManager_Level4 is not assigned!");
            }
        }
    }
}
