using UnityEngine;

namespace ThreeD_Sound_Game.Presenter
{
    public class SettingButtonPressPresenter : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        GameObject settingsWindow;
        bool isEnabled = false;
        #endregion

        public void Button_Clicked()
        {
            if (isEnabled)
            {
                isEnabled = false;
                settingsWindow.SetActive(false);
            }
            else
            {
                isEnabled = true;
                settingsWindow.SetActive(true);
            }
        }
    }
}
