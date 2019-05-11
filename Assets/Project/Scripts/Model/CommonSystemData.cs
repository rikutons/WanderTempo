using ThreeD_Sound_Game.Utility;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Model{
	public class CommonSystemData : DontDesSingletonMonoBehaviour<CommonSystemData> {
        #region private property
        ReactiveProperty<bool> isTutorialMode=new ReactiveProperty<bool>();
        #endregion

        #region public property
        public static ReactiveProperty<bool> IsTutorialMode { get { return Instance.isTutorialMode; } }
        #endregion
    }
}
