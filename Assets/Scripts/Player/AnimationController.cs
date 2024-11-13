using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIsMoving(bool isMoving)
    {
        animator.SetBool(IsMovingHash, isMoving);
    }
}