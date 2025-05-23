﻿using System;
using System.Collections;
using UnityEngine;

namespace Parasite
{
    public abstract class PowerSensor : MonoBehaviour
    {
        [SerializeField] protected int powerLevel;
        
        private bool _hasRequiredPower;
        
        public event Action OnPowerLevelAchieve;
        public event Action OnPowerLevelLose;
        
        public abstract void PowerUp();

        public abstract void PowerDown();
        
        private void Start()
        {
            StartCoroutine(WaitAndEvent());
        }

        private IEnumerator WaitAndEvent()
        {
            yield return null;
            
            PowerLevelEvent();
        }
        
        private void Update()
        {
            UpdatePowerLevel();
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