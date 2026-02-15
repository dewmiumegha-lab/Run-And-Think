using UnityEngine;
using TMPro;

public class AutoFocusInput : MonoBehaviour
{
    public TMP_InputField answerInput;

    void OnEnable()
    {
        answerInput.ActivateInputField(); 
    }

    void Update()
    {
        
        if (!answerInput.isFocused)
        {
            answerInput.ActivateInputField();
        }
    }
}
