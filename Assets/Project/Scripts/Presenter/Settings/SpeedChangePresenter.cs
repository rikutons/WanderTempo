using ThreeD_Sound_Game.Model;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

namespace ThreeD_Sound_Game.Presenter
{
    public class SpeedChangePresenter : MonoBehaviour
    {
        const float Range = 0.5f;
        const float LimitUpSpeed = 10f;
        const float LimitDownSpeed = 1f;

        #region private property
        [SerializeField]
        TextMeshProUGUI speedText;
        [SerializeField]
        Button speedUpButton;
        [SerializeField]
        Button speedDownButton;
        #endregion

        void Start()
        {
            Settings.NoteSpeed.Subscribe(speed =>
            {
                speedText.SetText(speed.ToString());
                if (Settings.NoteSpeed.Value == LimitUpSpeed)
                {
                    speedUpButton.interactable = false;
                }
                else
                {
                    speedUpButton.interactable = true;
                }
                if (Settings.NoteSpeed.Value == LimitDownSpeed)
                {
                    speedDownButton.interactable = false;
                }
                else
                {
                    speedDownButton.interactable = true;
                }
            }).AddTo(this);
        }
        public void UpButton_Clicked()
        {
            Settings.NoteSpeed.Value += Range;
        }

        public void DownButton_Clicked()
        {
            Settings.NoteSpeed.Value -= Range;
        }
    }
}
