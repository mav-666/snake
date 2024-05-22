using UnityEngine;

namespace Landmarks
{
    public class PointSpot : Spot
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 0.2f);
        }

        public override Vector3 GetPoint()
        {
            return transform.position;
        }
    }
}