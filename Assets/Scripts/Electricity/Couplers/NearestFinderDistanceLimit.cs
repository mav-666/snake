using UnityEngine;

namespace Electricity.Couplers
{
    public class NearestFinderDistanceLimit : NearestFinder
    {
        [SerializeField] private Transform target;
        [SerializeField] private float distanceLimit;

        public override bool Find(out Connectable found)
        {
            return base.Find(out found) && CheckDistanceOf(found.transform);
        }

        private bool CheckDistanceOf(Transform found)
        {
            return Vector3.Distance(target.position, found.position) <= distanceLimit;
        }
    }
}