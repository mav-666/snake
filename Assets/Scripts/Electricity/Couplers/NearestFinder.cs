using System;
using UnityEngine;

namespace Electricity.Couplers
{
    public class NearestFinder : Finder
    {
        [SerializeField] private float distance;
        [SerializeField] private LayerMask layerMask;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawRay(transform.position, transform.right * distance * transform.lossyScale.x);
        }

        public override bool Find(out Electric found)
        {
            var trans = transform;
            var hit = Physics2D.Raycast(trans.position, trans.right, distance * trans.lossyScale.x, layerMask);

            var hasFound = hit.collider != null;
            found = hasFound ? hit.collider.GetComponent<Electric>() : null;
            
            return hasFound;
        }
    }
}