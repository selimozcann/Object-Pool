using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public struct PoolData<T>
{
    [Header("DÝctionaryTag")]
    public string poolTag;

    [Header("PoolData")]
    public Transform poolParent;
    public int poolCount;
    public T poolObject;
    public Stack<GameObject> poolStack;
    public Vector3[] poolPosition;
    public Quaternion[] poolRotation;
}
public abstract class BaseObjectPool : MonoBehaviour
{
    [SerializeField] private PoolData<GameObject>[] poolData;
    [SerializeField] private Stack<GameObject> activedObjects;
    
    [SerializeField] protected GameObject currentPoolObject;

    

    private Dictionary<string, Stack<GameObject>> stackDict = new Dictionary<string, Stack<GameObject>>();
    protected virtual void InitalizePool()
    {
        activedObjects = new Stack<GameObject>();

        for (int i = 0; i < poolData.Length; i++)
        {
            poolData[i].poolStack = new Stack<GameObject>();

            for (int j = 0; j < poolData[i].poolCount; j++)
            {
                GameObject poolObj = Instantiate(poolData[i].poolObject,
                    poolData[i].poolPosition[i],poolData[i].poolRotation[i], poolData[i].poolParent);
                Debug.Log("PoolDataiPoolPos " + poolData[i].poolPosition[i]);
                poolObj.SetActive(false);
                poolObj.name = StringData.strCube + i as string;

                poolData[i].poolStack.Push(poolObj);

                
            }

            stackDict.Add(poolData[i].poolTag, poolData[i].poolStack);
        }
    }
    protected virtual GameObject GetPoolObject(string getPoolKey, bool canActive)
    {
        Debug.Log("Count =>>>>> ");
        if (!stackDict.ContainsKey(getPoolKey))
        {
            Debug.LogError("Dictionary key is not found  =>> Key is " + stackDict[getPoolKey]);
            return null;
        }
        if (canActive)
        {
            if (stackDict[getPoolKey].Count == 0)
            {
                Debug.Log("Pool is empty => Initalize pool");
                GameObject newcurrentObj = Instantiate(currentPoolObject,currentPoolObject.transform.parent);
                activedObjects.Push(newcurrentObj);
                return currentPoolObject;
            }

            currentPoolObject = stackDict[getPoolKey].Pop();

            activedObjects.Push(currentPoolObject);

            currentPoolObject.SetActive(canActive);
        }
        
        else 
        {

            if (activedObjects.Count == 0)
            {
                return null;
            }
            currentPoolObject = activedObjects.Pop();
            stackDict[getPoolKey].Push(currentPoolObject);
            currentPoolObject.SetActive(false);

            // currentPoolObject.SetActive(false);
            // currentPoolObject = stackDict[getPoolKey].Dequeue();
            // stackDict[getPoolKey].Enqueue(currentPoolObject);


        }
        return currentPoolObject;
    }
}
