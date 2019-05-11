using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.MasterData;
using ThreeD_Sound_Game.Utility;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class CalcScoresPresenter : MonoBehaviour
    {
        void Start()
        {
            JudgeScoreModel scoreData = Resources.Load<JudgeScoreModel>("JudgeScoreData");

            ScoresData.PerfectCount.
                Subscribe(_ =>
                {
                    ScoresData.MaxScore += scoreData.perfectScore;
                    ScoresData.Score.Value += scoreData.perfectScore;
                });
            ScoresData.GreatCount.
                Subscribe(_ => {
                    ScoresData.MaxScore += scoreData.perfectScore;
                    ScoresData.Score.Value += scoreData.greatScore;
                });
            ScoresData.GoodCount.
                Subscribe(_ =>
                {
                    ScoresData.MaxScore += scoreData.perfectScore;
                    ScoresData.Score.Value += scoreData.goodScore;
                });
            ScoresData.MissCount.
                Subscribe(_ =>
                    ScoresData.MaxScore += scoreData.perfectScore
                );

            ScoresData.MaxScore = 0;
            ScoresData.Score.Value = 0;
        }
    }
}
