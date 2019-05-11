using UnityEngine;

namespace ThreeD_Sound_Game.Utility
{
    public static class GameQuiter
    {
        public static void QuitGame()
        {
        #if UNITY_EDITOR
                    Debug.Log("Quit Game");
        #elif UNITY_STANDALONE
                    Application.Quit();
        #endif
        }
    }
}
