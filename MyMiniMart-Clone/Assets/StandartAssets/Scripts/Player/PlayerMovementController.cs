using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerControllerSettings playerControllerSettings;
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        SetRotationFreezeRb();
    }
    private void Update()
    {
        PlayerMoving();
    }
    private void PlayerMoving()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right 
            * variableJoystick.Horizontal;
        rb.velocity = direction * playerControllerSettings.Speed;
        transform.LookAt(transform.position + direction);
    }
    private void SetRotationFreezeRb()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
