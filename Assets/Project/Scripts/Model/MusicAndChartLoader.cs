using UnityEngine;
using System.Collections;
using System.IO;
using UniRx;

namespace ThreeD_Sound_Game.Model
{
    public class MusicAndChartLoader : MonoBehaviour
    {
        readonly string rootPath = "Charts";
        string chartPath;

        void Start()
        {
            chartPath = Path.Combine(Application.streamingAssetsPath, rootPath);
        }

        public void Load(string fileName)
        {
            StartCoroutine(LoadMusic(fileName));
            StartCoroutine(LoadChart(fileName));
        }

        IEnumerator LoadMusic(string fileName)
        {
            var oldPath = Path.Combine(chartPath, fileName);
            var path = Path.ChangeExtension(oldPath, ".wav");
            Debug.Log("Load start : " + path);
            if (!File.Exists(path))
            {
                Debug.Log("File not found.");
                yield break;
            }

            using (WWW www = new WWW("file://" + path))
            {
                while (!www.isDone)
                    yield return null;

                AudioClip audioClip = www.GetAudioClip(false, true);
                if (audioClip.loadState != AudioDataLoadState.Loaded)
                {
                    //ここにロード失敗処理
                    Debug.Log("Failed to load AudioClip.");
                    yield break;
                }

                //ここにロード成功処理
                Audio.Source.clip = audioClip;
                Debug.Log("Load success : " + path);
                Audio.OnLoad.OnNext(Unit.Default);
            }
        }

        IEnumerator LoadChart(string fileName)
        {
            var oldPath = Path.Combine(chartPath, fileName);
            var path = Path.ChangeExtension(oldPath, ".json");
            if (!File.Exists(path))
            {
                //ここにファイルが見つからない処理
                Debug.Log("File not found.");
                yield break;
            }
            var json = File.ReadAllText(path, System.Text.Encoding.UTF8);
            ChartDataSerializer.Deserialize(json);
        }
    }
}