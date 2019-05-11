using ThreeD_Sound_Game.Common;
using ThreeD_Sound_Game.MasterData;
using UnityEngine;

namespace ThreeD_Sound_Game.Generator
{
    public class SameTimeLineGenerator : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        GameObject sameTimeLinePrefab;
        [SerializeField]
        GameObject notesParent;
        #endregion

        public void Generate(int block, float speed)
        {
            var line = Instantiate(sameTimeLinePrefab);
            line.transform.parent = notesParent.transform;
            line.transform.position = new Vector3(0, (block / DetailConstants.BlockCountX) * DetailConstants.BlockDistanceY + 2, 0);
            line.GetComponent<Mover>().speed = speed;
        }
    }
}
