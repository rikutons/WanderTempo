using ThreeD_Sound_Game.MasterData;
using ThreeD_Sound_Game.Model;
using ThreeD_Sound_Game.Notes;
using UnityEngine;
using UniRx;
using System.Collections.Generic;

namespace ThreeD_Sound_Game.Presenter
{
    public class NoteInputPresenter : MonoBehaviour
    {
        #region public property
        public Subject<Unit>[] NoteInputDownObservables = new Subject<Unit>[8];
        public Subject<Unit>[] NoteInputObservables = new Subject<Unit>[8];
        public Subject<Unit>[] NoteInputUpObservables = new Subject<Unit>[8];
        public List<GameObject>[] Notes = new List<GameObject>[8];
        #endregion

        #region private property
        #endregion

        void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                NoteInputDownObservables[i] = new Subject<Unit>();
                NoteInputObservables[i] = new Subject<Unit>();
                NoteInputUpObservables[i] = new Subject<Unit>();
                Notes[i] = new List<GameObject>();
            }
        }

        void Update()
        {
            for (int i = 0; i < DetailConstants.BlockCountX; i++)
            {
                if (Input.GetButtonDown("Note" + (i + 1).ToString()))
                {
                    for (int j = 0; j < DetailConstants.BlockCountY; j++)
                    {
                        if (SystemData.FocusLine.Value == j)
                        {
                            int nowBlock = i + j * DetailConstants.BlockCountX;
                            NoteInputDownObservables[i + j * DetailConstants.BlockCountX].OnNext(Unit.Default);
                            if (Notes[nowBlock].Count == 0) continue;
                            if (Notes[nowBlock][0].GetComponent<NoteBeatingJudger>().JudgeBeating())
                            {
                                Destroy(Notes[nowBlock][0]);
                            };
                        }
                    }
                }
                if (Input.GetButton("Note" + (i + 1).ToString()))
                {
                    for (int j = 0; j < DetailConstants.BlockCountY; j++)
                    {
                        if (SystemData.FocusLine.Value == j)
                            NoteInputObservables[i + j * DetailConstants.BlockCountX].OnNext(Unit.Default);
                    }
                }
                if(Input.GetButtonUp("Note" + (i + 1).ToString()))
                {
                    for (int j = 0; j < DetailConstants.BlockCountY; j++)
                    {
                        if (SystemData.FocusLine.Value == j)
                            NoteInputUpObservables[i + j * DetailConstants.BlockCountX].OnNext(Unit.Default);
                    }
                }
            }
        }

        public void AddNote(int block,GameObject note)
        {
            Notes[block].Add(note);
        }

        public void OnDestroyNote(int block)
        {
            Notes[block].RemoveAt(0);
        }
    }
}
