using System.Collections;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class StateSignalHandler : SignalHandler
    {
        [SerializeField] private bool state;
        [SerializeField] private bool executeOnStart;

        private void Start()
        {
            if(executeOnStart)
                StartCoroutine(ExecuteOnStart());
        }

        private IEnumerator ExecuteOnStart()
        {
            yield return 0;
            
            ReceiveSignal();
        }
        
        public override void ReceiveSignal()
        {
            if(state)
               ExecuteAllOff();
            else
                ExecuteAllOn();

            state = !state;
        }
    }
}