using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.MasterData;
using ThreeD_Sound_Game.Common;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace ThreeD_Sound_Game.Presenter
{
    public class GenerateBPMLinePresenter : MonoBehaviour
    {
        readonly float WaitSecond = PlayAudioPresenter.WaitSecond;
        [SerializeField]
        GameObject BPMLinePrefab;
        [SerializeField]
        GameObject notesParent;
        void Start()
        {
            Audio.OnLoad.First().Subscribe(_ => Init());
        }

        void Init()
        {
            float interval = 60f / ChartData.BPM.Value;
            float nextInitTime = interval + WaitSecond - DetailConstants.PerfectTimingWhenSpeed1 / Settings.NoteSpeed.Value;
            while (nextInitTime < 0)
            {
                nextInitTime += interval;
            }
            this.UpdateAsObservable().
            Subscribe(_ =>
            {
                if (SystemData.GameSecond.Value >= nextInitTime)
                {
                    for (int i = 0; i < DetailConstants.BlockCountY; i++)
                    {
                        Generate(i * DetailConstants.BlockDistanceY, Settings.NoteSpeed.Value);
                    }
                    nextInitTime += interval;
                }
            });
        }

        public void Generate(float y, float speed)
        {
            var line = Instantiate(BPMLinePrefab);
            line.transform.parent = notesParent.transform;
            line.transform.position = new Vector3(0, y + 2, 0);
            line.GetComponent<Mover>().speed = speed;
        }
    }
}
