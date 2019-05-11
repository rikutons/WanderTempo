using UnityEngine;

namespace ThreeD_Sound_Game.MasterData
{
    public static class DetailConstants
    {
        #region block constants
        public static readonly int BlockCountX = 4;
        public static readonly int BlockCountY = 2;
        public static readonly float BlockDistanceX = 0.38f;
        public static readonly float BlockDistanceY = 0.75f;
        public static readonly float BlockZ = -7.9f;
        #endregion

        #region notes constants
        public static readonly float PerfectTimingWhenSpeed1 = 7.9f;
        public static readonly float EasingSecondWhenSpeed1 = 4.0f;
        public static readonly float LongNoteBodyInterval = 0.1f;
        #endregion

        #region for menu constants
        public static readonly float ButtonMoveSecond = 0.5f;
        public static readonly float MusicButtonDistanceX = 225f;
        public static readonly float MusicButtonDistanceY = 300f;
        public static readonly float MusicButtonInitY = 500f;
        public static readonly float MusicButtonCountX = 4;
        #endregion

        #region system constants
        public static readonly int WindowSizeX = 1024;
        #endregion

    }
}
