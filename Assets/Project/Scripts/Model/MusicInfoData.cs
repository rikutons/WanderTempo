using ThreeD_Sound_Game.Utility;
using ThreeD_Sound_Game.MasterData;
using UnityEngine;
using UniRx;
using System.Collections.Generic;

namespace ThreeD_Sound_Game.Model
{
    public class MusicInfoData : SingletonMonoBehaviour<MusicInfoData>
    {
        #region private property
        ReactiveProperty<string> genreName = new ReactiveProperty<string>();
        Subject<Unit> onLoad = new Subject<Unit>();
        #endregion
        #region public property
        public static Subject<Unit> OnLoad { get { return Instance.onLoad; } }
        public static ReactiveProperty<string> GenreName { get { return Instance.genreName; } }
        public static List<MusicInfoModel> MusicInfos;
        #endregion
    }
}
