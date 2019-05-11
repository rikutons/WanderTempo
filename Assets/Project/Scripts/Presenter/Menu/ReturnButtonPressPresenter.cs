using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class ReturnButtonPressPresenter : MonoBehaviour
    {
        public static Subject<Unit> OnPressed = new Subject<Unit>();
        [SerializeField]
        GameObject musicButtonCanvas;
        [SerializeField]
        GameObject genreButtonCanvas;

        public void Button_Clicked()
        {
            foreach (var musicButton in musicButtonCanvas.transform)
            {
                Destroy(((Transform)musicButton).gameObject);
            }
            genreButtonCanvas.SetActive(true);
            OnPressed.OnNext(Unit.Default);
            gameObject.SetActive(false);
        }
    }
}
