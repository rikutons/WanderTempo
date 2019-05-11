using ThreeD_Sound_Game.MasterData;
using UnityEngine;
using UniRx;
using DG.Tweening;

namespace ThreeD_Sound_Game.Presenter
{
    public class GoToMiddlePresenter : MonoBehaviour
    {
        #region private property
        [SerializeField]
        RectTransform rectTransform;
        Vector3 firstPos;
        #endregion

        void Start()
        {
            firstPos = rectTransform.position;
            GenreButtonPressPresenter.OnPressed.Subscribe(_ =>
            {
                rectTransform.DOMove(new Vector2(512, 384), DetailConstants.ButtonMoveSecond).SetEase(Ease.OutCubic);
            }).AddTo(this);
            ReturnButtonPressPresenter.OnPressed.Subscribe(_ =>
            {
                ResetPos();
            }).AddTo(this);
        }

        void ResetPos()
        {
            rectTransform.position = firstPos;
        }
    }
}
