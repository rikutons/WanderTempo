using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class EndButtonReplacePresenter : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        GameObject endButton;
        [SerializeField]
        GameObject returnButton;
        #endregion

        void Start()
        {
            GenreButtonPressPresenter.OnPressed.Subscribe(_ =>
            {
                returnButton.SetActive(true);
            }).AddTo(this);
        }
    }
}
