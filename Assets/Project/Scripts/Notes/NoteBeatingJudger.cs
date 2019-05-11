using ThreeD_Sound_Game.Common;
using ThreeD_Sound_Game.MasterData;
using ThreeD_Sound_Game.Presenter;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Notes
{
    public class NoteBeatingJudger : MonoBehaviour
    {
        #region protected property
        protected int block;
        #endregion
        #region private property
        JudgeTimingModel judgeTimingData;
        float time;
        float perfectTiming;

        public bool isAutoPlay;
        AudioSource source;
        NoteInputPresenter inputPresenter;
        protected bool isSingleNote = true;
        #endregion

        public void Init(int block, float speed, NoteInputPresenter inputPresenter)
        {
            judgeTimingData = Resources.Load<JudgeTimingModel>("JudgeTimingData");
            time = 0f;
            this.block = block;
            perfectTiming = DetailConstants.PerfectTimingWhenSpeed1 / speed;
            GetComponent<Mover>().speed = speed;
            if (isAutoPlay)
            {
                source = transform.parent.gameObject.GetComponent<AudioSource>();
            }
            AddBeatFunc(inputPresenter);
            this.inputPresenter = inputPresenter;
        }

        protected virtual void AddBeatFunc(NoteInputPresenter inputPresenter)
        {
            inputPresenter.AddNote(block, gameObject);
        }

        protected bool IsInPerfectAreaBack()
        {
            return time > perfectTiming &&
                   time < perfectTiming + judgeTimingData.perfectSecond;
        }

        protected void CheckMiss()
        {
            UpdateTime();
            if (IsOverJudgeArea())
            {
                AddJudgePresenter.AddJudge(JudgeTypes.Miss, block);
                Destroy(gameObject);
            }
        }

        void Update()
        {
            CheckMiss();
            if (isAutoPlay && IsInPerfectAreaBack())
            {
                AddJudgePresenter.AddJudge(JudgeTypes.Perfect, block);
                source.PlayOneShot(source.clip);
                Destroy(gameObject);
            }
        }

        void UpdateTime() { time += Time.deltaTime; }

        public bool JudgeBeating()
        {
            if (IsInJudgeArea())
            {
                if (IsInPerfectArea())
                    AddJudgePresenter.AddJudge(JudgeTypes.Perfect, block);
                else if (IsInGreatArea())
                    AddJudgePresenter.AddJudge(JudgeTypes.Great, block);
                else
                    AddJudgePresenter.AddJudge(JudgeTypes.Good, block);
                return true;
            }
            return false;
        }

        protected bool IsInJudgeArea()
        {
            var judgeAreaMin = perfectTiming - GetSumTimings(judgeTimingData);
            return time > judgeAreaMin && !IsOverJudgeArea();
        }

        bool IsOverJudgeArea()
        {
            var judgeAreaMax = perfectTiming + GetSumTimings(judgeTimingData);
            return time > judgeAreaMax;
        }

        bool IsInPerfectArea()
        {
            return time > perfectTiming - judgeTimingData.perfectSecond &&
                   time < perfectTiming + judgeTimingData.perfectSecond;
        }

        bool IsInGreatArea()
        {
            return time > perfectTiming - judgeTimingData.perfectSecond - judgeTimingData.greatSecond &&
                   time < perfectTiming + judgeTimingData.perfectSecond + judgeTimingData.greatSecond;
        }

        float GetSumTimings(JudgeTimingModel timings)
        {
            return timings.perfectSecond + timings.greatSecond + timings.goodSecond;
        }

        void OnDestroy()
        {
            if (isSingleNote)
                inputPresenter.OnDestroyNote(block);
        }
    }
}