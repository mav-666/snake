using System;
using Snake;
using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class SlowDownOnTimer : ObserveTimerHandler
    {
        [Serializable]
        private class MobilityAndSpeed
        {
            [SerializeField] private SegmentMobility segmentMobility;
            [SerializeField] private float maxSpeed;
            
            private float _originalMaxSpeed;

            public void Init()
            {
                _originalMaxSpeed = segmentMobility.maxSpeed;
            }

            public void ResetSpeed()
            {
                segmentMobility.maxSpeed = _originalMaxSpeed;
            }
            
            public void ChangeSpeed()
            {
                segmentMobility.maxSpeed = maxSpeed;
            }
        }

        [SerializeField] private MobilityAndSpeed[] mobilities;

        protected override void Awake()
        {
            base.Awake();
            foreach (var mobility in mobilities)
                mobility.Init();
        }

        protected override void OnStart(float leftTime)
        {
            foreach (var mobility in mobilities)
                mobility.ChangeSpeed();
        }

        protected override void OnEnd(float leftTime)
        {
            foreach (var mobility in mobilities)
                mobility.ResetSpeed();
        }
    }
}