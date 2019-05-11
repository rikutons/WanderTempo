using ThreeD_Sound_Game.Model;
using UnityEngine;
using TMPro;

namespace ThreeD_Sound_Game.Presenter
{
    public class AutoPlayButtonPressPresenter : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property

        [SerializeField]
        TextMeshProUGUI autoPlayText;
        #endregion

        public void Button_Clicked()
        {
            Settings.IsAutoPlay.Value = !Settings.IsAutoPlay.Value;
            if (Settings.IsAutoPlay.Value)
            {
                autoPlayText.SetText("On");
            }
            else
            {
                autoPlayText.SetText("Off");
            }
        }
    }
}
