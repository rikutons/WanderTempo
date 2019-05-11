using ThreeD_Sound_Game.Model;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace ThreeD_Sound_Game.Presenter
{
    public class TutorialImageReplacePresenter : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        Sprite[] tutoriaSprites;
        [SerializeField]
        Image image;
        [SerializeField]
        float replaceInterval;
        [SerializeField]
        GameObject spaceStarter;
        float replaceTime;
        int imageCount;
        #endregion

        void Start()
        {
            Audio.OnPlay.Subscribe(_ =>
            {
                imageCount = 0;
                replaceTime = PlayAudioPresenter.WaitSecond;
                Replace();
                this.UpdateAsObservable().Subscribe(__ =>
                {
                    if (SystemData.GameSecond.Value >= replaceTime)
                    {
                        Replace();
                    }
                });
            });
        }

        public void Replace()
        {
            if (imageCount >= tutoriaSprites.Length)
            {
                Debug.Log("Over tutorial length.");
                replaceTime = 10000000;
                return;
            }
            image.fillAmount = 1;
            spaceStarter.SetActive(true);
            EscapeButtonPressPresenter.GamePause.OnNext(Unit.Default);
            image.sprite = tutoriaSprites[imageCount];
            imageCount++;
            replaceTime += replaceInterval;
        }
    }
}
