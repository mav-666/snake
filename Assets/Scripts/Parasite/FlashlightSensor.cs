using System;
using System.Collections.Generic;
using UnityEngine;

namespace Parasite
{
    public class FlashlightSensor : MonoBehaviour
    {
        [SerializeField, Range(0, 180)] private float observeAngle;
        [SerializeField] private float radius;

        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private LayerMask obstacleLayers;
        
        public float ObserveAngle => observeAngle;
        public float Radius => radius;

        public event Action<Transform> OnFind; 
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            var trans = transform;
            
            var position = trans.position;
            var right = trans.right;
            
            Gizmos.DrawRay(position, Quaternion.Euler(0,0, observeAngle/2f) * right * radius);
            Gizmos.DrawRay(position, Quaternion.Euler(0,0, -observeAngle/2f) * right * radius);
        }
        
        private void Update()
        {
            foreach (var hit in FindInCircle())
                if(hit)
                    Check(hit.transform);
        }
        
        private IEnumerable<RaycastHit2D> FindInCircle()
        {
            return Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 1f, targetLayers);
        }

        private void Check(Transform target)
        {
            if (IsInObserveAngle(target) && HasNoObstacles(target))
            {
                Debug.Log(target.name + " : " + target.position);
                OnFind?.Invoke(target);
            }
                
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