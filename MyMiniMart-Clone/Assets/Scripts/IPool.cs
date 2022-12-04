using UnityEngine;

public interface IPool
{
   public void IGetPoolObject(string getPoolKey, bool canActive); 
}
public static class StringData
{
    public const string strSphere = "Sphere";
    public const string strCube = "Cube";

}
