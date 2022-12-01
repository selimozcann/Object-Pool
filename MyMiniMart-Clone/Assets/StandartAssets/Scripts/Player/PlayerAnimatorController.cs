using UnityEngine;

public enum PlayerAnimationType { Idle = 0, Run = 1 }
public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] private PlayerAnimationType playerAnimationType;

    private const string stranimationState = "AnimationState";
    public void OnRunAnimation()
    {
        playerAnim.SetInteger(stranimationState, (int)PlayerAnimationType.Run);
    }
    public void OnIdleAnimation()
    {
        playerAnim.SetInteger(stranimationState, (int)PlayerAnimationType.Idle);
    }
}
