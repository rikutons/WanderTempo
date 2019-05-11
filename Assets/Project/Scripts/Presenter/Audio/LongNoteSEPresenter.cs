using UnityEngine;

namespace ThreeD_Sound_Game.Presenter
{
    public class LongNoteSEPresenter : MonoBehaviour, ISEPresenter
    {
        #region private property
        [SerializeField]
        AudioSource noteSE;
        #endregion

        public void Play()
        {
            noteSE.PlayOneShot(noteSE.clip);
        }
    }
}
