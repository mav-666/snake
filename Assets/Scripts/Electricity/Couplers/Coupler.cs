using UnityEngine;

namespace Electricity.Couplers
{
    public abstract class Coupler : MonoBehaviour
    {
        protected Electric A;
        protected Electric B;

        public bool IsConnected { get; private set; }

        protected void Init(Electric a, Electric b)
        {
            A = a;
            B = b;
            
            A.Connect(this);
            B.Connect(this);
            
            IsConnected = true;
        }

        protected void Break()
        {
            IsConnected = false;
            
            A.Disconnect(this);
            B.Disconnect(this);
        }

        public void Transmit(Electric sender)
        {
            if(!IsConnected)
                return;
            
            if(sender == A)
                TransmitFromA();
            else if(sender == B)
                TransmitFromB();
        }

        protected abstract void TransmitFromA();
        
        protected abstract void TransmitFromB();
    }
}