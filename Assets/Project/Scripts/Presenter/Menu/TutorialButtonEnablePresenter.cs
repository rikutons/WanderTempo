using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.MusicButtons;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class TutorialButtonEnablePresenter : MonoBehaviour
    {
        [SerializeField]
        GameObject tutorialButton;

        private void Start()
        {
            ReturnButtonPressPresenter.OnPressed.Subscribe(_ =>{
                tutorialButton.SetActive(true);
            }
            ).AddTo(this);
            GenreButtonPressPresenter.OnPressed.Subscribe(_ => {
                tutorialButton.SetActive(false);
            }
            ).AddTo(this);
        }
    }
}
