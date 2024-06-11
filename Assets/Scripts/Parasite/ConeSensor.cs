using System.Collections.Generic;
using UnityEngine;

namespace Parasite
{
    public class ConeSensor : MonoBehaviour
    {
        [SerializeField, Range(0, 360)] private float observeAngle;
        [SerializeField] private float radius;

        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private LayerMask obstacleLayers;
        
        public float ObserveAngle => observeAngle;
        public float Radius => radius;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            var trans = transform;
            
            var position = trans.position;
            var right = trans.right;
            
            Gizmos.DrawRay(position, Quaternion.Euler(0,0, observeAngle/2f) * right * radius);
            Gizmos.DrawRay(position, Quaternion.Euler(0,0, -observeAngle/2f) * right * radius);
        }
        
        private IEnumerable<RaycastHit2D> FindInCircle()
        {
            return Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 1f, targetLayers);
        }

        public bool Check(out GameObject target)
        {
            foreach (var hit in FindInCircle())
            {
                if (!hit || !CheckOne(hit.transform)) 
                    continue;

                target = hit.collider.gameObject;
                return true;
            }

            target = null;
            return false;
        }
        
        private bool CheckOne(Transform target)
        {
            return IsInObserveAngle(target) && HasNoObstacles(target);
        }
        

        private bool IsInObserveAngle(Transform target)
        {
            var trans = transform;
            var angle = Vector2.Angle(trans.right, (target.position - trans.position).normalized);

            return angle <= observeAngle/2f;
        }
        
        private bool HasNoObstacles(Transform target)
        {
            var hit = Physics2D.Linecast(transform.position, target.position, obstacleLayers);

            return !hit;
        }
    }
}