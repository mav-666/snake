using DG.Tweening;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class DelayedExecutor : SignalExecutor
    {
        private enum Order { On, Off, Both }
        
        [SerializeField] private SignalExecutor signalExecutor;
        [SerializeField] private float delay;
        [SerializeField] private Order order;

        private Tween _temp;
        
        public override void ExecuteOn()
        {
            if (order != Order.Off)
            {
                signalExecutor.ExecuteOn();
                return;
            }
                
            _temp?.Kill();
            _temp = DOVirtual.DelayedCall(delay,() => signalExecutor.ExecuteOn());
        }

        public override void ExecuteOff()
        {
            if (order != Order.On)
            {
                signalExecutor.ExecuteOff();
                return;
            }
            
            _temp?.Kill();
            _temp = DOVirtual.DelayedCall(delay,() => signalExecutor.ExecuteOff());
        }
    }
}