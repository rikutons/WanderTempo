using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class ChangeLineColorPresenter : MonoBehaviour
    {
        #region public property
        [HideInInspector]
        public int LineNum { private get; set; }
        #endregion

        #region private property
        [SerializeField]
        new LineRenderer renderer;
        #endregion

        void Start()
        {
            SystemData.FocusLine.Subscribe(line =>
            {
                if (line == LineNum)
                {
                    renderer.endColor = Color.white;
                }
                else
                {
                    renderer.endColor = new Color(1f, 0f, 0f, 0.1f);
                }
            });
        }
    }
}
