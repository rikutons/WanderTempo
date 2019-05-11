using UnityEngine;

namespace ThreeD_Sound_Game.Common
{
    public class Mover : MonoBehaviour
    {
        #region public property
        public float speed;
        public Vector3 moveVector;
        #endregion

        #region private property
        protected Rigidbody rb;
        #endregion

        void Start()
        {
            moveVector = Vector3.Normalize(moveVector);
            rb = GetComponent<Rigidbody>();
            rb.velocity = moveVector * speed;
        }
    }
}