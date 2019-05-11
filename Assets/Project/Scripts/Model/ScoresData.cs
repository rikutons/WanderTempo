using ThreeD_Sound_Game.Utility;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Model{
	public class ScoresData : SingletonMonoBehaviour<ScoresData> {
        #region private property
        ReactiveProperty<int> score = new ReactiveProperty<int>(0);
        ReactiveProperty<int> perfectCount = new ReactiveProperty<int>(0);
        ReactiveProperty<int> greatCount = new ReactiveProperty<int>(0);
        ReactiveProperty<int> goodCount = new ReactiveProperty<int>(0);
        ReactiveProperty<int> missCount = new ReactiveProperty<int>(0);
        #endregion
        public static ReactiveProperty<int> Score { get { return Instance.score; } }
        public static ReactiveProperty<int> PerfectCount { get { return Instance.perfectCount; } }
        public static ReactiveProperty<int> GreatCount { get { return Instance.greatCount; } }
        public static ReactiveProperty<int> GoodCount { get { return Instance.goodCount; } }
        public static ReactiveProperty<int> MissCount { get { return Instance.missCount; } }
        public static int MaxScore;
        #region public property

        #endregion
    }
}
