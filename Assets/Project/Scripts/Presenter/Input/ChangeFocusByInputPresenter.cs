using ThreeD_Sound_Game.MasterData;
using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class ChangeFocusByInputPresenter : MonoBehaviour
    {
        void Update()
        {
            int countY = DetailConstants.BlockCountY;
            if (Input.GetButtonDown("Up"))
            {
                SystemData.FocusLine.Value = (SystemData.FocusLine.Value + 1) % countY;
            }
            else if (Input.GetButtonDown("Down"))
            {
                SystemData.FocusLine.Value = (SystemData.FocusLine.Value - 1 + countY) % countY;
            }
        }
    }
}
