using UnityEngine;
using UnityEngine.SceneManagement;
namespace ThreeD_Sound_Game.Presenter
{
    public class QuitButtonPresenter : MonoBehaviour
    {
        public void Button_Clicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SelectMusic");
        }
    }
}
