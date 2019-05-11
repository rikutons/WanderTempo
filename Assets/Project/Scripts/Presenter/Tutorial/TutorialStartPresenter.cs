using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class TutorialStartPresenter : MonoBehaviour
    {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        GameObject scoreText;
        [SerializeField]
        GameObject spaceStarter;
        #endregion

        void Start()
        {
            if (CommonSystemData.IsTutorialMode.Value)
            {
                foreach (var child in transform)
                {
                    ((Transform)child).gameObject.SetActive(true);
                }
                scoreText.SetActive(false);
                spaceStarter.SetActive(false);
            }
            else
            {
                foreach (var child in transform)
                {
                    ((Transform)child).gameObject.SetActive(false);
                }
            }
        }
    }
}
