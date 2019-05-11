using ThreeD_Sound_Game.Presenter;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using System.IO;

namespace ThreeD_Sound_Game.MusicButtons
{
    public class MusicLoader : MonoBehaviour
    {
        
        private string genre;

        public void SetGenre(string genre)
        {
            this.genre = genre;
        }

        public void LoadButton_OnClick()
        {
            Debug.Log(genre);
            string path = Path.Combine(Path.Combine(genre, gameObject.name), gameObject.name);
            Load(path);
        }

        public void Load(string path)
        {
            SceneManager.LoadSceneAsync("MusicGame").AsObservable()
                .Subscribe(_ =>
                {
                    var loadChartPresenter = FindObjectOfType<LoadChartPresenter>() as LoadChartPresenter;
                    loadChartPresenter.Parameter = new LoadChartPresenter.LoadParameter { MusicTitle = path };
                });
        }
    }
}
