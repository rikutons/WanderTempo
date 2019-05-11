using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace ThreeD_Sound_Game.Presenter
{
    public class TimeUpdatePresenter : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        GameObject loading;
        [SerializeField]
        GameObject loadingImage;
        [SerializeField]
        GameObject loadingBack;
        #endregion

        void Start()
        {
            Audio.OnLoad.Subscribe(_ => BoostTime());
            Audio.OnPlay.Subscribe(_ => Init());
        }

        void BoostTime()
        {
            Time.timeScale = 3;
            this.UpdateAsObservable().
                TakeWhile(_ => Time.timeScale == 3).
                Subscribe(_ =>
                {
                    SystemData.GameSecond.Value += Time.deltaTime;
                    if (SystemData.GameSecond.Value >= PlayAudioPresenter.WaitSecond)
                    {
                        SystemData.GameSecond.Value = PlayAudioPresenter.WaitSecond;
                        Time.timeScale = 1;
                        Destroy(loading);
                        Destroy(loadingImage);
                        Destroy(loadingBack);
                    }
                });
        }

        void Init()
        {
            this.UpdateAsObservable().
                Subscribe(_ => SystemData.GameSecond.Value += Time.deltaTime);
        }
    }
}
