using Dreamteck.Splines;
using UnityEngine;

namespace Landmarks
{
    public class SplineSpot : Spot
    {
        [SerializeField] private Transform target;
        [SerializeField] private SplineComputer spline;
        
        public override Vector3 GetPoint()
        {
            return spline.Project(target.position).position;
        }
    }
}