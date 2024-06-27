using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class IgnoreFirstSignal : SignalExecutor
    {
        [SerializeField] private SignalExecutor signalExecutor;

        private bool _isFirst = true;

        public override void ExecuteOn()
        {
            if (_isFirst)
                _isFirst = false;
            else
                signalExecutor.ExecuteOn();
        }

        public override void ExecuteOff()
        {
            if (_isFirst)
                _isFirst = false;
            else
                signalExecutor.ExecuteOff();
        }
    }
}