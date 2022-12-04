using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;

    private delegate void pooldelegate(bool canActive);
    private event pooldelegate OnInputKeyA;
    private event pooldelegate OnInputKeyP;



    private void OnEnable()
    {
        OnInputKeyA += CheckGetToPool;
        OnInputKeyP += CheckGetToPool;
    }
    private void OnDisable()
    {
        OnInputKeyA -= CheckGetToPool;
        OnInputKeyP -= CheckGetToPool;
    }
    private void Update()
    {
        bool isActive = Input.GetKeyDown(KeyCode.A);
        bool isPassive = Input.GetKeyDown(KeyCode.D);

        if (isActive)
        {
            OnInputKeyA?.Invoke(true);
        }
        if (isPassive)
        {
            Debug.Log("IsPassive");
            OnInputKeyP?.Invoke(false);
        }
    }
    public void CheckGetToPool(bool canActive)
    {
        objectPool.IGetPoolObject(StringData.strCube,canActive);
    }
}
