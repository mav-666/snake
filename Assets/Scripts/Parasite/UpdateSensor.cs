
using System;
using UnityEngine;

namespace Parasite
{
    [RequireComponent(typeof(ConeSensor))]
    public class UpdateSensor : MonoBehaviour
    {
        public event Action<bool> OnObserve;

        private bool _hasTarget;
        
        private ConeSensor _sensor;

        private void Awake()
        {
            _sensor = GetComponent<ConeSensor>();
        }
        
        private void Update()
        {
            if(_sensor.Check(out _))
                FoundTarget();
            else
                LostTarget();
        }
        
        private void LostTarget()
        {
            if (!_hasTarget)
                return;
            
            _hasTarget = false;
            OnObserve?.Invoke(false);
        }

        private void FoundTarget()
        {
            if(_hasTarget)
                return;

            _hasTarget = true;
            OnObserve?.Invoke(true);
        }

    }
}