using UnityEngine;
public class Base : MonoBehaviour
{
    /// <summary>
    /// (dx,dy)だけ移動させる
    /// </summary>
    /// <param name="dx"></param>
    /// <param name="dy"></param>
    public void Move(float dx, float dy)
    {
        gameObject.transform.position += new Vector3(dx, dy, 0);
    }
}