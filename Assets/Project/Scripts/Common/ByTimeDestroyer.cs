using UnityEngine;

namespace ThreeD_Sound_Game.Common{
	public class ByTimeDestroyer : MonoBehaviour {
        [SerializeField]
        float destroyTime;
        float time;
        void Start () {
            time = 0;
		}
		
		void Update () {
            time += Time.deltaTime;
            if (time > destroyTime)
            {
                Destroy(gameObject);
            }
		}
	}
}
