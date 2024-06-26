using DG.Tweening;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class DelayedExecutor : SignalExecutor
    {
        [SerializeField] private SignalExecutor signalExecutor;
        [SerializeField] private float delay;

        private Tween _temp;
        
        public override void ExecuteOn()
        {
            _temp?.Kill();
            _temp = DOVirtual.DelayedCall(delay,() => signalExecutor.ExecuteOn());
        }

        public override void ExecuteOff()
        {
            _temp?.Kill();
            _temp = DOVirtual.DelayedCall(delay,() => signalExecutor.ExecuteOn());
        }
    }
}