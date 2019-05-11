using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;
using TMPro;

namespace ThreeD_Sound_Game.Presenter
{
    public class MusicNameTextPresenter : MonoBehaviour
    {
        #region private property
        [SerializeField]
        TextMeshProUGUI musicNameText;
        #endregion

        void Start()
        {
            Audio.OnLoad.Subscribe(_ => musicNameText.SetText(ChartData.Name.Value));
        }
    }
}
