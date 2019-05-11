using ThreeD_Sound_Game.MasterData;
using UnityEngine;
using DG.Tweening;

namespace ThreeD_Sound_Game.Common
{
    public class OutCubicPosEaser : MonoBehaviour
    {
        #region public property
        public Vector3 moveVector;
        #endregion

        #region private property
        static float easingSecond;
        float x, y, z;
        Tweener tweener;
        #endregion

        public static void SetEasingSecond(float noteSpeed)
        {
            easingSecond = DetailConstants.EasingSecondWhenSpeed1 / noteSpeed;
        }

        void Start()
        {
            var endPos = this.transform.position + moveVector;
            x = endPos.x;
            y = endPos.y;
            z = endPos.z;
            if (moveVector.x != 0)
                transform.DOMoveX(x, easingSecond).SetEase(Ease.OutCubic).SetLoops(1);
            if (moveVector.y != 0)
                transform.DOMoveY(y, easingSecond).SetEase(Ease.OutCubic).SetLoops(1);
            if (moveVector.z != 0)
                transform.DOMoveZ(z, easingSecond).SetEase(Ease.OutCubic).SetLoops(1);
        }
    }
}
