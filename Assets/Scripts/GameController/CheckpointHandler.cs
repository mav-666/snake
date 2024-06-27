using System;
using Electricity;
using Landmarks;
using Parasite;
using UnityEngine;

namespace GameController
{
    public class CheckpointHandler : MonoBehaviour
    {
        [Serializable]
        private class Landmark
        {
            [SerializeField] private Spot spot;
            [SerializeField] private Area area;
            [SerializeField] private ParasiteEye[] eyesToClose;
            [SerializeField] private Electric[] electricToActivate;
            
            public Spot Spot => spot;
            public Area Area => area;
            public Electric[] ElectricToActivate => electricToActivate;
        }
        
        private static int _currentLandmarkID;
        
        [SerializeField] private Transform target;
        [SerializeField] private Transform spawn;
        [SerializeField] private Landmark[] landmarks;

        private void FixedUpdate()
        {
            CheckArea(target.position);
        }
        
        private void CheckArea(Vector3 point)
        {
            for (var i = 0; i < landmarks.Length; i++)
            {
                var landMark = landmarks[i];
                if (landMark.Area.IsInside(point))
                    _currentLandmarkID = i;
            }
        }

        public void LoadCheckPoint()
        {
            var currentLandmark = landmarks[_currentLandmarkID];
            
            spawn.transform.SetPositionAndRotation(currentLandmark.Spot.GetPoint(), currentLandmark.Spot.transform.rotation);

            foreach (var electric in currentLandmark.ElectricToActivate)
                electric.ReceiveSignal(null);
        }

        public void Reset()
        {
            _currentLandmarkID = 0;
        }
    }
}