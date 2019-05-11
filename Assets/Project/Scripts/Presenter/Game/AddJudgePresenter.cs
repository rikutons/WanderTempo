using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.Utility;
using UnityEngine;

namespace ThreeD_Sound_Game.Presenter
{
    public class AddJudgePresenter : SingletonMonoBehaviour<AddJudgePresenter>
    {
        [SerializeField]
        GameObject[] judgeEffects;
        public static void AddJudge(JudgeTypes judgeType, int block)
        {
            GameObject effect = null;
            var effectPos = BlockToPosSerializer.Serialize(block);
            switch (judgeType)
            {
                case JudgeTypes.Perfect:
                    ScoresData.PerfectCount.Value++;
                    effect = Instantiate(Instance.judgeEffects[(int)JudgeTypes.Perfect]);
                    break;
                case JudgeTypes.Great:
                    ScoresData.GreatCount.Value++;
                    effect = Instantiate(Instance.judgeEffects[(int)JudgeTypes.Great]);
                    break;
                case JudgeTypes.Good:
                    ScoresData.GoodCount.Value++;
                    effect = Instantiate(Instance.judgeEffects[(int)JudgeTypes.Good]);
                    break;
                case JudgeTypes.Miss:
                    ScoresData.MissCount.Value++;
                    effect = Instantiate(Instance.judgeEffects[(int)JudgeTypes.Miss]);
                    break;
            }
            effect.transform.position = effectPos;
        }
    }
}
