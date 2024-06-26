using UnityEngine;

namespace Electricity.SignalHandlers
{
    [RequireComponent(typeof(Electric))]
    public abstract class SignalHandler : MonoBehaviour
    {
        
        private SignalExecutor[] _executors;

        protected virtual void Awake()
        {
            _executors = GetComponents<SignalExecutor>();
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