using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class BeatSEPresenter : MonoBehaviour, ISEPresenter
    {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        AudioSource beatingSE;
        [SerializeField]
        NoteInputPresenter inputPresenter;
        #endregion

        void Start()
        {
            foreach (var observable in inputPresenter.NoteInputDownObservables)
            {
                observable.Subscribe(_ => Play());
            }
        }

        public void Play()
        {
            beatingSE.PlayOneShot(beatingSE.clip);
        }
    }
}
