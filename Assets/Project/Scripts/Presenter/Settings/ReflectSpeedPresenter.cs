using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.Common;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class ReflectSpeedPresenter : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property

        #endregion

        void Start()
        {
            ReflectSpeed(Settings.NoteSpeed.Value);
            Settings.NoteSpeed.Subscribe(noteSpeed =>
            {
                ReflectSpeed(noteSpeed);
            }
            );
        }

        void ReflectSpeed(float noteSpeed)
        {
            OutCubicPosEaser.SetEasingSecond(noteSpeed);
        }
    }
}
