using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerAnimatorController playerAnimatorController;
    [SerializeField] private PlayerControllerSettings playerControllerSettings;
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        SetRotationFreezeRb();
    }
    private void FixedUpdate()
    {
        PlayerMoving();
    }
    private void PlayerMoving()
    {
        bool canMove = variableJoystick.Direction == Vector2.zero;
        if (canMove)
        {
            playerAnimatorController.OnIdleAnimation();
            return;
        }

        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right 
            * variableJoystick.Horizontal;
        rb.velocity = direction * playerControllerSettings.Speed;
        transform.LookAt(transform.position - direction);
        playerAnimatorController.OnRunAnimation();
    }
    private void SetRotationFreezeRb()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
