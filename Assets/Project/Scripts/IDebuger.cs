using UnityEngine;

public class IDebuger : MonoBehaviour
{
    static public void Log<T>(T obj)
    {
        Debug.Log(obj.ToString());
    }
}
