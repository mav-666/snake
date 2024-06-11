using UnityEngine;

namespace Parasite
{
    public abstract class ObserveTimerHandler : MonoBehaviour
    {
        private ObserveTimer _observeTimer;

        protected virtual void Awake()
        {
            _observeTimer = GetComponent<ObserveTimer>();
        }

        private void OnEnable()
        {
            _observeTimer.OnObserveStart += OnStart;
            _observeTimer.OnObserveEnd += OnEnd;
        }
        
        private void OnDisable()
        {
            _observeTimer.OnObserveStart -= OnStart;
            _observeTimer.OnObserveEnd -= OnEnd;
        }

        protected abstract void OnStart(float leftTime);
        protected abstract void OnEnd(float leftTime);
    }
}