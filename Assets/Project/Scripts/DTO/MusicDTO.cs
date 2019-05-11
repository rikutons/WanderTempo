using System.Collections.Generic;

namespace ThreeD_Sound_Game.DTO
{
    public class MusicDTO
    {
        [System.Serializable]
        public class ChartData
        {
            public string name;
            public int maxBlock;
            public float BPM;
            public int offset;
            public List<ParentNote> notes;
        }

        [System.Serializable]
        public class ParentNote
        {
            public int LPB;
            public int num;
            public int block;
            public int type;
            public List<Note> notes;
        }

        [System.Serializable]
        public class Note
        {
            public int LPB;
            public int num;
            public int block;
            public int type;
        }
    }
}
