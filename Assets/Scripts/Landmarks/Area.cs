    using UnityEngine;

namespace Landmarks
{
    public abstract class Area : MonoBehaviour
    {
        [SerializeField] private int priority;

        public int Priority => priority;

        public abstract bool IsInside(Vector3 point);
    }
}