using System;
using UnityEngine;

namespace Parasite
{
    public abstract class PowerSensor : SensorHandler
    {
        [SerializeField] private int startPowerLevel;

        protected int _powerLevel;

        private bool _hasRequiredPower;
        
        public event Action OnPowerLevelAchieve;
        public event Action OnPowerLevelLose;
        
        public abstract void PowerUp();

        public abstract void PowerDown();

        protected override void Awake()
        {
            base.Awake();
            _powerLevel = startPowerLevel;
        }

        private void Start()
        {
            if(_hasRequiredPower)
                OnPowerLevelAchieve?.Invoke();
            else
                OnPowerLevelLose?.Invoke();
        }

        private void Update()
        {
            UpdatePowerLevel();
            
            if(_hasRequiredPower && _sensor.Check(out _))
                FoundTarget();
            else
                LostTarget();
        }


        private void UpdatePowerLevel()
        {
            if (_hasRequiredPower == CheckRequiredPowerLevel())
                return;

            _hasRequiredPower = !_hasRequiredPower;
            PowerLevelEvent();
        }

        private void PowerLevelEvent()
        {
            if(_hasRequiredPower)
                OnPowerLevelAchieve?.Invoke();
            else
                OnPowerLevelLose?.Invoke();
        }
            
        protected abstract bool CheckRequiredPowerLevel();
    }
}