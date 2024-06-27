using GameController;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class TimerSignalHandler : SignalHandler
    {
        [SerializeField] private float enabledTime;
        private SignalExecutor[] _executors;

        private Timer _timer;
        
        protected override void Awake()
        {
            base.Awake();
            
            enabledTime += 0.1f;
            _timer = new Timer();
        }

        public override void ReceiveSignal()
        {
            _timer.Start(enabledTime);
            ExecuteAllOn();
        }

        private void Update()
        {
            if(_timer.Update(Time.deltaTime))
                ExecuteAllOff();
        }
    }
}