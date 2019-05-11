using ThreeD_Sound_Game.MasterData;
using ThreeD_Sound_Game.Presenter;
using UnityEngine;

namespace ThreeD_Sound_Game.Generator
{
    public class VerticalLineGenerator : MonoBehaviour
    {
        #region private property
        [SerializeField]
        GameObject verticalLinePrefab;
        #endregion

        void Start()
        {
            var distanceX = DetailConstants.BlockDistanceX;
            var distanceY = DetailConstants.BlockDistanceY;
            var lineCountX = DetailConstants.BlockCountX + 1;
            var lineCountY = DetailConstants.BlockCountY;
            var leftx = -distanceX * (lineCountX - 1) / 2;
            for (int i = 0; i < lineCountX; i++)
            {
                for (int j = 0; j < lineCountY; j++)
                {
                    var line = Instantiate(verticalLinePrefab);
                    line.transform.position = new Vector3(leftx + distanceX * i, j * distanceY, 0);
                    line.transform.parent = this.transform;
                    line.GetComponent<ChangeLineColorPresenter>().LineNum = j;
                }
            }
        }
    }
}
