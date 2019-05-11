using ThreeD_Sound_Game.MasterData;
using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;
using TMPro;

namespace ThreeD_Sound_Game.Presenter
{
    public class RankJudgePresenter : MonoBehaviour
    {
        #region private property
        [SerializeField]
        TextMeshProUGUI rankText;
        #endregion

        void Start()
        {
            Rank[] ranks = Resources.Load<RankPercentsModel>("RankPercentsModel").RankPercents;
            Audio.OnFinishPlaying.Subscribe(_ =>
            {
                var percent = (float)ScoresData.Score.Value / ScoresData.MaxScore * 100f;
                foreach(var rank in ranks)
                {
                    if (percent >= rank.percent)
                    {
                        rankText.SetText(rank.rankName);
                        rankText.color = rank.color;
                        break;
                    }
                }
            });
        }

        void Update()
        {

        }
    }
}
