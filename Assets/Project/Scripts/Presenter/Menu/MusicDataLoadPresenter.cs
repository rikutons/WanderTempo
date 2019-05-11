using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.MasterData;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ThreeD_Sound_Game.Presenter
{
    public class MusicDataLoadPresenter : MonoBehaviour
    {
        #region private property
        readonly string musicDataPath = "MusicInfoData";
        #endregion

        void Start()
        {
            GenreButtonPressPresenter.
                OnPressed.
                Delay(System.TimeSpan.FromSeconds(DetailConstants.ButtonMoveSecond)).
                Subscribe(genre =>
                {
                    Load(genre);
                });
        }

        void Load(string genre)
        {
            var musicInfosArray = Resources.LoadAll<MusicInfoModel>(Path.Combine(musicDataPath, genre));

            var musicInfos = new List<MusicInfoModel>(musicInfosArray);
            MusicInfoData.MusicInfos = musicInfos;
            MusicInfoData.OnLoad.OnNext(Unit.Default);
        }
    }
}
