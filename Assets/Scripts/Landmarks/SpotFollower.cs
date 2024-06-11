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
            [SerializeField] private float zoom = 4.6f;
            
            public Spot Spot => spot;
            public Area Area => area;
            public float Zoom => zoom;
        }

        [SerializeField] private Landmark[] landmarks;
        [SerializeField] private Transform target;
        [SerializeField] private Spot defaultSpot;
        [SerializeField] private float defaultZoom = 4.4f;
        [SerializeField] private float speed;
        
        private Landmark _currentLandmark;
        private bool IsValidArea => _currentLandmark != null;
        private float _zPos;

        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
            
            Array.Sort(landmarks, (a, b) => a.Area.Priority.CompareTo(b.Area.Priority));
            _zPos = transform.position.z;

            SetPos(defaultSpot.GetPoint());
        }

        private void FixedUpdate()
        {
            var point = target.position;

            if(!IsValidArea || !_currentLandmark.Area.IsInside(point))
                FindNewAreaBy(point);

            var spot = IsValidArea ? _currentLandmark.Spot : defaultSpot;
            LerpToSpot(spot);
            
            var zoom = IsValidArea ? _currentLandmark.Zoom : defaultZoom;
            LerpToZoom(zoom);
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

        private void LerpToZoom(float zoom)
        {
            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, zoom, Time.deltaTime * speed);
        }

        private void SetPos(Vector3 pos)
        {
            pos.z = _zPos;
            transform.position = pos;
        }
    }
}