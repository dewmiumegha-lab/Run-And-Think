using UnityEngine;

public class MMCharacterAnimater : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Looking Around"); // Make sure the name matches the clip
    }
}
