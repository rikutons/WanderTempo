using ThreeD_Sound_Game.Utility;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Model
{
    public class Settings : DontDesSingletonMonoBehaviour<Settings>
    {
        #region private property
        ReactiveProperty<float> noteSpeed = new ReactiveProperty<float>(6f);
        ReactiveProperty<bool> isAutoPlay = new ReactiveProperty<bool>(false);
        #endregion

        #region public property
        public static ReactiveProperty<float> NoteSpeed { get { return Instance.noteSpeed; } }
        public static ReactiveProperty<bool> IsAutoPlay { get { return Instance.isAutoPlay; } }
        #endregion
    }
}
