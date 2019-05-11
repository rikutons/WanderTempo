using ThreeD_Sound_Game.MasterData;
using UnityEngine;

namespace ThreeD_Sound_Game.Utility
{
    public static class BlockToPosSerializer
    {
        public static Vector3 Serialize(int block)
        {
            var initXPosBlock0 = -(DetailConstants.BlockCountX - 1) * DetailConstants.BlockDistanceX / 2;
            var x = initXPosBlock0 + (block % DetailConstants.BlockCountX) * DetailConstants.BlockDistanceX;
            var y = (block / DetailConstants.BlockCountX) * DetailConstants.BlockDistanceY;
            return new Vector3(x, y, DetailConstants.BlockZ);
        }
    }
}
