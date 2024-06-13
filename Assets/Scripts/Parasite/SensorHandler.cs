using System;
using UnityEngine;

namespace Parasite
{
    [RequireComponent(typeof(ConeSensor))]
    public abstract class SensorHandler : MonoBehaviour
    {
        private bool _hasTarget;
        protected ConeSensor _sensor;
        public event Action<bool> OnObserve;

        protected virtual void Awake()
        {
            _sensor = GetComponent<ConeSensor>();
        }
        
        protected void FoundTarget()
        {
            if(_hasTarget)
                return;

            _hasTarget = true;
            OnObserve?.Invoke(true);
        }
        
        protected void LostTarget()
        {
            if (!_hasTarget)
                return;
            
            _hasTarget = false;
            OnObserve?.Invoke(false);
        }
    }
}