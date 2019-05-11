using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class GenreButtonPressPresenter : MonoBehaviour
    {
        #region public property
        static public Subject<string> OnPressed = new Subject<string>();
        #endregion

        public void Button_Clicked()
        {
            CommonSystemData.IsTutorialMode.Value = false;
            transform.SetAsLastSibling();
            OnPressed.OnNext(gameObject.name);
            MusicInfoData.GenreName.Value = gameObject.name;
        }
    }
}