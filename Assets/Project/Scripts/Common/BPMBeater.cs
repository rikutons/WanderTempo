using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace ThreeD_Sound_Game.Common
{
    public class BPMBeater : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property
        Animator animator;
        #endregion

        public void BeatByBPM(int BPM)
        {
            InitAnimator();
            animator.speed = BPM / 60.0f;
        }

        void InitAnimator()
        {
            if (animator == null)
                animator = GetComponent<Animator>();
        }
    }
}
