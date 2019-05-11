using ThreeD_Sound_Game.Model;
using UnityEngine;
using TMPro;

namespace ThreeD_Sound_Game.Presenter
{
    public class LoadChartPresenter : MonoBehaviour
    {
        public class LoadParameter
        {
            public string MusicTitle { get; set; }
        }
        #region public property
        public LoadParameter Parameter { get; set; }
        #endregion

        #region private property
        [SerializeField]
        string titleAtError;
        #endregion

        void Start()
        {
            if (Parameter == null)
            {
                Parameter = new LoadParameter { MusicTitle = titleAtError };
            }
            var loader = GetComponent<MusicAndChartLoader>();
            loader.Load(Parameter.MusicTitle);
        }
    }
}
