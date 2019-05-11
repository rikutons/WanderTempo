using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game._Test{
	public class MessageWatcher : MonoBehaviour {
		#region public property

		#endregion

		#region private property

		#endregion

		void Start () {
            Audio.OnLoad.Subscribe(_ => IDebuger.Log("OnLoad Subscribe!"));
		}
		
		void Update () {
			
		}
	}
}
