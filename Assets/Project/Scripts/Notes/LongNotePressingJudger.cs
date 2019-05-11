using ThreeD_Sound_Game.Presenter;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Notes
{
    public class LongNotePressingJudger : NoteBeatingJudger
    {
        #region private property
        ISEPresenter beatSE;
        #endregion

        public void LongNoteInit(int block, float speed, NoteInputPresenter inputPresenter, ISEPresenter longNoteSE)
        {
            Init(block, speed, inputPresenter);
            this.beatSE = longNoteSE;
            isSingleNote = false;
        }

        protected override void AddBeatFunc(NoteInputPresenter inputPresenter)
        {
            inputPresenter.NoteInputObservables[block]
                    .Subscribe(_ => JudgePlessing())
                    .AddTo(this);
            inputPresenter.NoteInputUpObservables[block]
                .Subscribe(_ => JudgeUpButton())
                .AddTo(this);
        }

        void JudgePlessing()
        {
            if (IsInPerfectAreaBack())
            {
                AddJudgePresenter.AddJudge(JudgeTypes.Perfect, block);
                beatSE.Play();
                Destroy(gameObject);
            }
        }

        void JudgeUpButton()
        {
            if (IsInJudgeArea())
            {
                beatSE.Play();
                JudgeBeating();
                Destroy(gameObject);
            }
        }
        void Update()
        {
            CheckMiss();
            if (isAutoPlay&&IsInPerfectAreaBack())
            {
                AddJudgePresenter.AddJudge(JudgeTypes.Perfect, block);
                beatSE.Play();
                Destroy(gameObject);
            }
        }
    }
}
