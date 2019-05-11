using ThreeD_Sound_Game.MasterData;
using UnityEngine;
using System.Collections.Generic;

namespace ThreeD_Sound_Game.MusicButtons
{
    public class MusicButtonGenerator : MonoBehaviour
    {
        #region private property
        [SerializeField]
        GameObject musicButtonPrefab;
        #endregion

        public void GenerateButtons(List<MusicInfoModel> musicInfos, string genreName)
        {
            var initX = -DetailConstants.MusicButtonDistanceX * (DetailConstants.MusicButtonCountX - 1) / 2f + DetailConstants.WindowSizeX / 2;
            Vector2 initPos =
                new Vector2(
                    initX,
                    DetailConstants.MusicButtonInitY);
            int count = 0;
            foreach (var musicInfo in musicInfos)
            {
                var musicButton = Instantiate(musicButtonPrefab);
                musicButton.GetComponent<MusicButtonInitializar>().Init(musicInfo, genreName);
                musicButton.transform.position = initPos;
                musicButton.transform.SetParent(this.transform);
                count++;
                if (count % DetailConstants.MusicButtonCountX == 0)
                {
                    initPos.x = initX;
                    initPos.y += DetailConstants.MusicButtonDistanceY;
                }
                else
                {
                    initPos.x += DetailConstants.MusicButtonDistanceX;
                }
            }
        }
    }
}
