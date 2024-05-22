using System;
using UnityEngine;

namespace Landmarks
{
    [RequireComponent(typeof(Camera))]
    public class SpotFollower : MonoBehaviour
    {
        [Serializable]
        private class Landmark
        {
            [SerializeField] private Spot spot;
            [SerializeField] private Area area;

            public Spot Spot => spot;
            public Area Area => area;
        }

        [SerializeField] private Landmark[] landmarks;
        [SerializeField] private Transform target;
        [SerializeField] private Spot defaultSpot;
        [SerializeField] private float speed;
        
        private Landmark _currentLandmark;
        private bool ValidArea => _currentLandmark != null;
        private float _zPos;

        private void Start() 
        {
            Array.Sort(landmarks, (a, b) => a.Area.Priority.CompareTo(b.Area.Priority));
            _zPos = transform.position.z;

            SetPos(defaultSpot.GetPoint());
        }

        private void FixedUpdate()
        {
            var point = target.position;

            if(!ValidArea || !_currentLandmark.Area.IsInside(point))
                FindNewAreaBy(point);

            var spot = ValidArea ? _currentLandmark.Spot : defaultSpot;
            LerpToSpot(spot);
        }

        private void FindNewAreaBy(Vector3 point)
        {
            foreach (var landMark in landmarks)
            {
                if (!landMark.Area.IsInside(point))
                    continue;
                
                _currentLandmark = landMark;
                return;
            }

            _currentLandmark = null;
        }
        
        private void LerpToSpot(Spot spot)
        {
            SetPos(Vector3.Lerp(transform.position, spot.GetPoint(), Time.deltaTime * speed));
        }

        private void SetPos(Vector3 pos)
        {
            pos.z = _zPos;
            transform.position = pos;
        }
    }
}