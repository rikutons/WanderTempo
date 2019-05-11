using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;
using TMPro;

namespace ThreeD_Sound_Game.Presenter{
	public class ShowScorePresenter : MonoBehaviour {

        #region private property
        [SerializeField]
        TextMeshProUGUI scoreText;
        #endregion

        void Start () {
            ScoresData.Score.Subscribe(score =>
            {
                scoreText.SetText("Score:" + score.ToString());
            });
		}
	}
}
