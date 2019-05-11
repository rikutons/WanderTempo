using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.MusicButtons;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class MButtonGeneratePresenter : MonoBehaviour
    {
        #region private property
        [SerializeField]
        MusicButtonGenerator musicButtonGenerator;
        #endregion

        void Start()
        {
            MusicInfoData.OnLoad.Subscribe(_ => musicButtonGenerator.GenerateButtons(MusicInfoData.MusicInfos,MusicInfoData.GenreName.Value));
        }
    }
}
