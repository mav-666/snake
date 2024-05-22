namespace Electricity
{
    public class StateSignalHandler : SignalHandler
    {
        private bool _state;
        
        public override void ReceiveSignal()
        {
            if(_state)
               ExecuteAllOff();
            else
                ExecuteAllOn();

            _state = !_state;
        }
    }
}