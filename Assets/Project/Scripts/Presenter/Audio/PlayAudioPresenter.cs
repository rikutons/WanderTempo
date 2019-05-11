using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Collections;

namespace ThreeD_Sound_Game.Presenter
{
    public class PlayAudioPresenter : MonoBehaviour
    {
        public static readonly float WaitSecond = 10;
        void Start()
        {
            Audio.OnLoad.Subscribe(_ => StartCoroutine(WaitAndPlayAudio()));
            Audio.OnPlay.Subscribe(_ =>
            {
                Observable.Timer(System.TimeSpan.FromSeconds(3)).Subscribe(__ =>
                {
                    this.UpdateAsObservable().Subscribe(___ =>
                    {
                        if (!Audio.Source.isPlaying && Audio.Source.time == 0)
                        {
                            Audio.OnFinishPlaying.OnNext(Unit.Default);
                        }
                    });
                });
                EscapeButtonPressPresenter.GamePause.Subscribe(__ => Audio.Source.Pause());
                EscapeButtonPressPresenter.GameStart.Subscribe(__ => Audio.Source.UnPause());
            });
            

        }

        IEnumerator WaitAndPlayAudio()
        {
            yield return new WaitForSeconds(WaitSecond);
            PlayAudio();
        }

        void PlayAudio()
        {
            Audio.Source.Play();
            Debug.Log("Play Audio Start.Time:" + Time.time.ToString());
            Audio.OnPlay.OnNext(Unit.Default);
        }
    }
}
