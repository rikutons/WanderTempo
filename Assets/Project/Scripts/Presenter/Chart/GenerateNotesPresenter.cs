using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.Notes;
using ThreeD_Sound_Game.Generator;
using ThreeD_Sound_Game.MasterData;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace ThreeD_Sound_Game.Presenter
{
    public class GenerateNotesPresenter : MonoBehaviour
    {
        readonly static float WaitSecond = PlayAudioPresenter.WaitSecond;
        void Start()
        {
            Audio.OnLoad.First().Subscribe(_ => Init());
        }

        void Init()
        {
            int iterator = 0;
            var nextNote = ChartData.Notes[iterator];
            float initTime = GetNoteInitTime(nextNote.startPosition);
            var noteGenerator = this.GetComponent<NoteGenerator>();
            var sameTimeLineGenerator = this.GetComponent<SameTimeLineGenerator>();
            if (Settings.IsAutoPlay.Value)
            {
                noteGenerator.isAutoPlay = true;
            }
            Debug.Log("Note Genarate Start.Time:" + Time.time.ToString());
            this.UpdateAsObservable().
            TakeWhile(_ => iterator < ChartData.Notes.Count).
            Subscribe(_ =>
            {
                int sameTimeNoteCount = 0;
                while (true)
                {
                    if (SystemData.GameSecond.Value >= initTime)
                    {
                        if (nextNote.startPosition.block < DetailConstants.BlockCountX * DetailConstants.BlockCountY)
                        {
                            switch (nextNote.type)
                            {
                                case NoteTypes.Single:
                                    noteGenerator.Generate(nextNote.startPosition.block, Settings.NoteSpeed.Value);
                                    sameTimeNoteCount++;
                                    break;
                                case NoteTypes.Long:
                                    var endSecond = GetNoteInitTime(nextNote.endPosition);
                                    noteGenerator.LongNoteGenerate(nextNote.startPosition.block, Settings.NoteSpeed.Value, endSecond - SystemData.GameSecond.Value);
                                    break;
                                default:
                                    break;
                            }
                        }
                        iterator++;
                        if (sameTimeNoteCount == 2)
                        {
                            sameTimeLineGenerator.Generate(nextNote.startPosition.block, Settings.NoteSpeed.Value);
                        }
                        if (iterator < ChartData.Notes.Count)
                        {
                            nextNote = ChartData.Notes[iterator];
                            initTime = GetNoteInitTime(nextNote.startPosition);
                        }
                        else break;
                    }
                    else break;
                }
            });
        }

        public static float GetNoteInitTime(NotePosition pos)
        {
            return (float)pos.num / pos.LPB / ((float)ChartData.BPM.Value / 60)
                - DetailConstants.PerfectTimingWhenSpeed1 / Settings.NoteSpeed.Value
                + ChartData.OffsetSamples.Value / 45000f + WaitSecond;
        }
    }
}
