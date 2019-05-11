using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class RestartButtonPresenter : MonoBehaviour
    {
        [SerializeField]
        LoadChartPresenter oldLoadChartPresenter;
        public void Button_Clicked()
        {
            Time.timeScale = 1;
            Scene loadScene = SceneManager.GetActiveScene();

            string path = oldLoadChartPresenter.Parameter.MusicTitle;
            SceneManager.LoadSceneAsync(loadScene.name).AsObservable()
                .Subscribe(_ =>
                {
                    var loadChartPresenter = FindObjectOfType<LoadChartPresenter>() as LoadChartPresenter;
                    loadChartPresenter.Parameter = new LoadChartPresenter.LoadParameter { MusicTitle = path };
                });
        }
    }
}
