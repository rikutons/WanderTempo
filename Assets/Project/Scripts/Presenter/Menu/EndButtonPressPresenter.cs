using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThreeD_Sound_Game.Presenter{
	public class EndButtonPressPresenter : MonoBehaviour {
        public void Button_Clicked()
        {
            SceneManager.LoadScene("Opening");
        }
	}
}