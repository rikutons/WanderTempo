using UnityEngine;
using System.Collections.Generic;

namespace ThreeD_Sound_Game.Common
{
    public class VerticalLineDrawer : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        LineRenderer lineRenderer;
        [SerializeField]
        Vector3 startEasePos;
        [SerializeField]
        Vector3 endEasePos;
        [SerializeField]
        Vector3 endPos;
        [SerializeField]
        int vertexNum;
        float t;
        #endregion

        void Start()
        {
            List<Vector3> rendererPoints = new List<Vector3>();
            t = 0;
            endEasePos -= startEasePos;
            for (int i = 0; i <= vertexNum; i++)
            {
                var y = GetOutQubic(t, startEasePos.y, endEasePos.y);
                rendererPoints.Add(new Vector3(0, y, startEasePos.z + endEasePos.z * t));
                t += 1f / vertexNum;
            }
            rendererPoints.Add(endPos);
            lineRenderer.positionCount = rendererPoints.Count;
            lineRenderer.SetPositions(rendererPoints.ToArray());
        }

        float GetOutQubic(float t, float start, float end)
        {
            t = t - 1;

            return end * (t * t * t + 1) + start;
        }
    }
}
