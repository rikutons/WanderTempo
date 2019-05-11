using ThreeD_Sound_Game.Notes;
using ThreeD_Sound_Game.Presenter;
using ThreeD_Sound_Game.Utility;
using ThreeD_Sound_Game.Common;
using ThreeD_Sound_Game.MasterData;
using UnityEngine;
using UniRx;
using System;

namespace ThreeD_Sound_Game.Generator
{
    public class NoteGenerator : MonoBehaviour
    {
        public bool isAutoPlay;

        #region private property
        [SerializeField]
        GameObject[] notePrefabs;
        [SerializeField]
        GameObject[] longNoteHeadPrefabs;
        [SerializeField]
        GameObject[] longNoteBodyPrefabs;
        [SerializeField]
        GameObject[] longNoteTailPrefabs;
        [SerializeField]
        GameObject notesParent;
        [SerializeField]
        NoteInputPresenter inputPresenter;
        [SerializeField]
        LongNoteSEPresenter longNoteSEPresenter;
        [SerializeField]
        BeatSEPresenter beatSEPresenter;
        [SerializeField]
        Vector3 notePos;
        #endregion

        public void Generate(int block, float speed)
        {
            int lineNum = block / DetailConstants.BlockCountX;
            var note = Instantiate(notePrefabs[lineNum]);
            note.transform.parent = notesParent.transform;
            note.transform.position = BlockToPosSerializer.Serialize(block) + notePos;
            if (isAutoPlay)
            {
                note.GetComponent<NoteBeatingJudger>().isAutoPlay = true;
            }
            note.GetComponent<NoteBeatingJudger>().Init(block, speed, inputPresenter);
        }

        public void LongNoteGenerate(int block, float speed, float endSecond)
        {
            LongNoteHeadGenerate(block, speed);
            var bodyDispasable = Observable.
                Interval(TimeSpan.FromSeconds(DetailConstants.LongNoteBodyInterval)).
                Subscribe(_ =>
                {
                    LongNoteBodyGenerate(block, speed);
                });
            Observable.
                Timer(TimeSpan.FromSeconds(endSecond)).
                Subscribe(_ =>
                {
                    bodyDispasable.Dispose();
                    LongNoteTailGenerate(block, speed);
                });
        }

        void LongNoteHeadGenerate(int block, float speed)
        {
            int lineNum = block / DetailConstants.BlockCountX;
            var longNoteHead = Instantiate(longNoteHeadPrefabs[lineNum]);
            longNoteHead.transform.parent = notesParent.transform;
            longNoteHead.transform.position = BlockToPosSerializer.Serialize(block) + notePos;
            if (isAutoPlay)
            {
                longNoteHead.GetComponent<NoteBeatingJudger>().isAutoPlay = true;
            }
            longNoteHead.GetComponent<NoteBeatingJudger>().Init(block, speed, inputPresenter);
        }

        void LongNoteBodyGenerate(int block, float speed)
        {
            int lineNum = block / DetailConstants.BlockCountX;
            var longNoteBody = Instantiate(longNoteBodyPrefabs[lineNum]);
            longNoteBody.transform.parent = notesParent.transform;
            longNoteBody.transform.position = BlockToPosSerializer.Serialize(block) + notePos;
            if (isAutoPlay)
            {
                longNoteBody.GetComponent<NoteBeatingJudger>().isAutoPlay = true;
            }
            longNoteBody.GetComponent<LongNotePressingJudger>().LongNoteInit(block, speed, inputPresenter, longNoteSEPresenter);
        }

        void LongNoteTailGenerate(int block, float speed)
        {
            int lineNum = block / DetailConstants.BlockCountX;
            var longNoteTail = Instantiate(longNoteTailPrefabs[lineNum]);
            longNoteTail.transform.parent = notesParent.transform;
            longNoteTail.transform.position = BlockToPosSerializer.Serialize(block) + notePos;
            if (isAutoPlay)
            {
                longNoteTail.GetComponent<NoteBeatingJudger>().isAutoPlay = true;
            }
            longNoteTail.GetComponent<LongNotePressingJudger>().LongNoteInit(block, speed, inputPresenter, beatSEPresenter);
        }
    }
}
