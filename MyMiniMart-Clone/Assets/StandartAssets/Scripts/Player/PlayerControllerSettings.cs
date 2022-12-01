using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerControllerSettings", fileName = "PlayerControllerSettings")]
public class PlayerControllerSettings : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed { get { return speed; } }
}
