using ThreeD_Sound_Game.Model;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class ChangeBackGroundPresenter : MonoBehaviour
    {
        #region private property
        [SerializeField]
        Sprite[] backGrounds;
        [SerializeField]
        Image image;
        [SerializeField]
        GameObject genreButtonParent;
        #endregion

        void Start()
        {
            MusicInfoData.OnLoad.Subscribe(_ =>
            {
                ChangeSprite(1);
                genreButtonParent.SetActive(false);
            });
        }

        public void ChangeSprite(int num)
        {
            image.sprite = backGrounds[num];
        }
    }
}
