using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace ThreeD_Sound_Game.Presenter{
	public class ByEnterKeyStartPresenter : MonoBehaviour {
        [SerializeField]
        Image tutorialImage;
		void Update () {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                EscapeButtonPressPresenter.GameStart.OnNext(Unit.Default);
                gameObject.SetActive(false);
                tutorialImage.fillAmount = 0.348f;
            }
        }
	}
}
