 using System;
using Electricity;
using GameController;
using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class ObserveTimer : MonoBehaviour
    {
        [SerializeField] private ParasiteEye[] sensors;

        [SerializeField] private float timespan;
        
        public event Action<float> OnObserveStart;
        public event Action<float> OnObserveEnd;
        public event Action OnReachEnd;
        
        private BiTimer _timer;
        private int _activeSensorsCount;
        
        private void OnEnable()
        {
            foreach (var sensor in sensors)
                sensor.OnObserve += Handle;
        }
        
        private void OnDisable()
        {
            foreach (var sensor in sensors)
                sensor.OnObserve -= Handle;
        }
        
        private void Awake()
        {
            _timer = new BiTimer();
        }

        private void Update()
        {
            if(_timer.Update(Time.deltaTime) && _timer.IsIncrement)
                OnReachEnd?.Invoke();
        }

        private void Handle(bool hasFound)
        {
            if (hasFound)
                FindTarget();
            else
                LostTarget();
        }

        private void FindTarget()
        {
            if (_timer.HasReachedBorder)
                _timer.Start(timespan);
            else
                _timer.SetIncrement(true);
            
            OnObserveStart?.Invoke(_timer.LeftTime);
        }

        private void LostTarget()
        {
            if (_timer.HasReachedBorder)
                _timer.Start(timespan, false);
            else
                _timer.SetIncrement(false);
            
            OnObserveEnd?.Invoke(_timer.LeftTime);
        }
    }
}