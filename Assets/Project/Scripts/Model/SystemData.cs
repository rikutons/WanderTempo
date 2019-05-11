using ThreeD_Sound_Game.Utility;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Model
{
    public class SystemData : SingletonMonoBehaviour<SystemData>
    {
        #region private property
        ReactiveProperty<float> gameSecond = new ReactiveProperty<float>(0);
        ReactiveProperty<float> musicEndTime = new ReactiveProperty<float>(0);
        ReactiveProperty<int> focusLine = new ReactiveProperty<int>(0);
        #endregion

        #region public property
        public static ReactiveProperty<float> GameSecond { get { return Instance.gameSecond; } }
        public static ReactiveProperty<float> MusicEndTime { get { return Instance.musicEndTime; } }
        public static ReactiveProperty<int> FocusLine { get { return Instance.focusLine; } }
        #endregion
    }
}
