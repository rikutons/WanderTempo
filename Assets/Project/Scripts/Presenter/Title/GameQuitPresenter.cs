using ThreeD_Sound_Game.Utility;
using UnityEngine;

namespace ThreeD_Sound_Game.Presenter
{
    public class GameQuitPresenter : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property

        #endregion

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameQuiter.QuitGame();
            }
        }
    }
}
