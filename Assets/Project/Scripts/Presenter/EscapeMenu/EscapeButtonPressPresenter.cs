using ThreeD_Sound_Game.Model;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace ThreeD_Sound_Game.Presenter
{
    public class EscapeButtonPressPresenter : MonoBehaviour
    {
        #region private property
        public static Subject<Unit> GamePause = new Subject<Unit>();
        public static Subject<Unit> GameStart = new Subject<Unit>();
        bool isPausing = false;
        [SerializeField]
        Sprite stopButton;
        [SerializeField]
        Sprite playButton;
        [SerializeField]
        Image image;
        [SerializeField]
        GameObject escapeContentsParent;
        bool isFinishPlaying;
        #endregion


        void Start()
        {
            Audio.OnPlay.Subscribe(_ =>
            {
                this.UpdateAsObservable().TakeWhile(__ => !isFinishPlaying).Subscribe(___ =>
                 {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            Button_Clicked();
                        }
                    });
            });
            Audio.OnFinishPlaying.Subscribe(_ =>
            {
                isFinishPlaying = true;
            });

            GameStart.Subscribe(_ => Time.timeScale = 1);
            GamePause.Subscribe(_ => Time.timeScale = 0);
        }

        public void Button_Clicked()
        {
            if (isPausing)
            {
                image.sprite = stopButton;
                isPausing = false;
                escapeContentsParent.SetActive(false);
                GameStart.OnNext(Unit.Default);
            }
            else
            {
                image.sprite = playButton;
                isPausing = true;
                escapeContentsParent.SetActive(true);
                GamePause.OnNext(Unit.Default);
            }
        }
    }
}
