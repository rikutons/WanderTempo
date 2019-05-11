using UnityEngine;

namespace ThreeD_Sound_Game.Common
{
    public class ScreenInitlizer : MonoBehaviour
    {
        void Start()
        {
            Screen.SetResolution(1024, 768, false);
        }
    }
}
