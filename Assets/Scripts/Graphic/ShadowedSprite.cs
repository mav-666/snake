using UnityEngine;
using UnityEngine.Rendering;

namespace Graphic
{
    public class ShadowedSprite : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<SpriteRenderer>().shadowCastingMode = ShadowCastingMode.On;
        }
    }
}