using UnityEngine;

public class AnimatorIdle : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found!, please insert");
        }

        animator.Play("Idle");
    }
}
