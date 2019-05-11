using UnityEngine;
using UnityEngine.SceneManagement;
namespace ThreeD_Sound_Game.Presenter{
	public class MenuLoadPresenter : MonoBehaviour {
		#region public property

		#endregion

		#region private property

		#endregion

		void Update () {
            if (Input.GetKeyDown(KeyCode.Space)||
                Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SelectMusic");
            }
		}
	}
}
