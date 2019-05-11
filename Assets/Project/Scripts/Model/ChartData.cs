using ThreeD_Sound_Game.Utility;
using ThreeD_Sound_Game.Notes;
using System.Collections.Generic;
using UniRx;

namespace ThreeD_Sound_Game.Model
{
    public class ChartData : SingletonMonoBehaviour<ChartData>
    {
        #region private property
        new ReactiveProperty<string> name = new ReactiveProperty<string>();
        ReactiveProperty<int> maxBlock = new ReactiveProperty<int>(5);
        ReactiveProperty<int> LPB_ = new ReactiveProperty<int>(4);
        ReactiveProperty<float> BPM_ = new ReactiveProperty<float>(120f);
        ReactiveProperty<int> offsetSamples = new ReactiveProperty<int>(0);
        List<Note> notes = new List<Note>();
        #endregion

        #region public property
        public static ReactiveProperty<string> Name { get { return Instance.name; } }
        public static ReactiveProperty<int> MaxBlock { get { return Instance.maxBlock; } }
        public static ReactiveProperty<int> LPB { get { return Instance.LPB_; } }
        public static ReactiveProperty<float> BPM { get { return Instance.BPM_; } }
        public static ReactiveProperty<int> OffsetSamples { get { return Instance.offsetSamples; } }
        public static List<Note> Notes { get { return Instance.notes; } }
        #endregion
    }
}

