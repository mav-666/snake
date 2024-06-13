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
            _observeTimer.OnReachEnd += OnReachEnd;
        }
        
        private void OnDisable()
        {
            _observeTimer.OnObserveStart -= OnStart;
            _observeTimer.OnObserveEnd -= OnEnd;
            _observeTimer.OnReachEnd -= OnReachEnd;
        }

        protected abstract void OnStart(float leftTime);
        protected abstract void OnEnd(float leftTime);

        protected virtual void OnReachEnd()
        {
            OnDisable();
        }
    }
}