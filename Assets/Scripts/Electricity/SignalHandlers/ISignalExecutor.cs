using UnityEngine;

namespace Electricity.SignalHandlers
{
    public abstract class SignalExecutor : MonoBehaviour
    {
        public abstract void ExecuteOn();
        
        public abstract void ExecuteOff();
    }
}