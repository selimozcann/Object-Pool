using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 forceAmonut;
    public Vector3 ForceAmonut
    {
        get => forceAmonut;
        set => forceAmonut = value;
    }
    private void FixedUpdate()
    {
        // OnForceAmount();
    }
    private void OnForceAmount()
    {
        rb.AddForce(forceAmonut, ForceMode.Impulse);
    }
}
