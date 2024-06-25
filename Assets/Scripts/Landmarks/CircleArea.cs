using UnityEngine;

namespace Landmarks
{
    public class CircleArea : Area
    {
        [SerializeField] private float radius;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
      
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public override bool IsInside(Vector3 point)
        {
            return Vector3.Distance(transform.position, point) <= radius;
        }
    }
}