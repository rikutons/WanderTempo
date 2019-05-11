using UnityEngine;

namespace ThreeD_Sound_Game.MasterData{
    [System.Serializable]
    public class Rank
    {
        public string rankName;
        public float percent;
        public Color color;
    }
	public class RankPercentsModel : ScriptableObject {
        public Rank[] RankPercents;
	}
}
