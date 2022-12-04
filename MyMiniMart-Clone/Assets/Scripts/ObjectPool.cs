using UnityEngine;

public class ObjectPool : BaseObjectPool,IPool
{
    private void Start()
    {
        InitalizePool();
    }
    protected override void InitalizePool()
    {
        base.InitalizePool();
    }
    protected override GameObject GetPoolObject(string getPoolKey,bool canActive)
    {
        return base.GetPoolObject(getPoolKey,canActive);
    }
    public void IGetPoolObject(string getPoolKey,bool canActive)
    {
        GetPoolObject(getPoolKey,canActive);
    }
}
