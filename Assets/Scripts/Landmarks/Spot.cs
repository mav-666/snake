using UnityEngine;

namespace Landmarks
{
    public abstract class Spot : MonoBehaviour
    {
        public abstract Vector3 GetPoint();
    }
}