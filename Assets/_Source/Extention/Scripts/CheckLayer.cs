using UnityEngine;

namespace Extention
{
    public static class CheckLayer
    {
        public static bool IsInLayer(this GameObject obj, LayerMask layer) =>
            (layer & 1 << obj.layer) != 0;
    }
}
