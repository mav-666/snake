using UnityEngine;

namespace Electricity
{
    [CreateAssetMenu]
    public class LampConfig : ScriptableObject
    {
        public float duration;
        [Header("Flash animation")]
        public float amplitude;
        public float period;
        public Color turnedOff;
    }
}