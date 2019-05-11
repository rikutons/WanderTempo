using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.MusicButtons;
using UnityEngine;

namespace ThreeD_Sound_Game.Presenter
{
    public class TutorialButtonPressPresenter : MonoBehaviour
    {

        public void Button_Clicked()
        {
            CommonSystemData.IsTutorialMode.Value = true;
            GetComponent<MusicLoader>().Load("tutorial\\dont-hero");
        }
    }
}
