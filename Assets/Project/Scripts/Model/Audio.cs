using ThreeD_Sound_Game.Utility;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Model{
	public class Audio : SingletonMonoBehaviour<Audio> {
        #region private property
        AudioSource source_;
        Subject<Unit> onLoad = new Subject<Unit>();
        Subject<Unit> onPlay = new Subject<Unit>();
        Subject<Unit> onFinishPlaying = new Subject<Unit>();
        ReactiveProperty<float> volume_ = new ReactiveProperty<float>(1);
        ReactiveProperty<bool> isPlaying_ = new ReactiveProperty<bool>(false);
        ReactiveProperty<int> timeSamples_ = new ReactiveProperty<int>(0);
        ReactiveProperty<float> smoothedTimeSamples_ = new ReactiveProperty<float>(0);
        #endregion

        #region public property
        public static AudioSource Source
        {
            get { return Instance.source_ ?? (Instance.source_ = Instance.gameObject.AddComponent<AudioSource>()); }
        }
        public static Subject<Unit> OnLoad { get { return Instance.onLoad; } }
        public static Subject<Unit> OnPlay { get { return Instance.onPlay; } }
        public static Subject<Unit> OnFinishPlaying { get { return Instance.onFinishPlaying; } }
        public static ReactiveProperty<float> Volume { get { return Instance.volume_; } }
        public static ReactiveProperty<bool> IsPlaying { get { return Instance.isPlaying_; } }
        public static ReactiveProperty<int> TimeSamples { get { return Instance.timeSamples_; } }
        public static ReactiveProperty<float> SmoothedTimeSamples { get { return Instance.smoothedTimeSamples_; } }
        #endregion
    }
}
