using UnityEngine;

namespace ThreeD_Sound_Game.Common{
	public class ByPosDestroyer : MonoBehaviour {
        #region public property

        #endregion

        #region private property
        [SerializeField]
        Vector3 pos1;
        [SerializeField]
        Vector3 pos2;
        #endregion

		void Update () {
            var objectPos = transform.position;

            if (objectPos.x < pos1.x || objectPos.x > pos2.x ||
                objectPos.y < pos1.y || objectPos.y > pos2.y ||
                objectPos.z < pos1.z || objectPos.z > pos2.z)
                Destroy(gameObject);

        }
	}
}
