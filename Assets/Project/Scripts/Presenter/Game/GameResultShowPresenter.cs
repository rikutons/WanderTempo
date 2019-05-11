using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;
using TMPro;

namespace ThreeD_Sound_Game.Presenter{
	public class GameResultShowPresenter : MonoBehaviour {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        GameObject resultParent;
        [SerializeField]
        TextMeshProUGUI scoreText;
        [SerializeField]
        TextMeshProUGUI perfectText;
        [SerializeField]
        TextMeshProUGUI greatText;
        [SerializeField]
        TextMeshProUGUI goodText;
        [SerializeField]
        TextMeshProUGUI missText;
        #endregion

        void Start () {
            Audio.OnFinishPlaying.Subscribe(_ =>
            {
                resultParent.SetActive(true);
                scoreText.SetText(ScoresData.Score.Value.ToString());
                perfectText.SetText(ScoresData.PerfectCount.Value.ToString());
                greatText.SetText(ScoresData.GreatCount.Value.ToString());
                goodText.SetText(ScoresData.GoodCount.Value.ToString());
                missText.SetText(ScoresData.MissCount.Value.ToString());
            });
		}
	}
}
