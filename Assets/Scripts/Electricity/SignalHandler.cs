using UnityEngine;

namespace Electricity
{
    [RequireComponent(typeof(Electric))]
    public abstract class SignalHandler : MonoBehaviour
    {
        
        private ISignalExecutor[] _executors;

        protected virtual void Awake()
        {
            _executors = GetComponents<ISignalExecutor>();
        }

        public abstract void ReceiveSignal();

        protected void ExecuteAllOn()
        {
            foreach (var executor in _executors)
                executor.ExecuteOn();
        }
        
        protected void ExecuteAllOff()
        {
            foreach (var executor in _executors)
                executor.ExecuteOff();
        }
    }
}