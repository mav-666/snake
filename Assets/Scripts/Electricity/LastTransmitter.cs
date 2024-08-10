using System.Linq;
using Electricity.Couplers;
using UnityEngine;

namespace Electricity
{
    public class LastTransmitter : Electric
    {
        public override bool ReceiveSignal(Coupler sender)
        {
            base.ReceiveSignal(sender);

            var last = _couplers.Last();
            
            return sender == last ? OrdinarySend(sender) : LastSend(last);
        }
        
        private bool OrdinarySend(Coupler sender)
        {
            Disconnect(sender);
            
            var isSent = SendSignal();
            Connect(sender);
            return isSent;
        }

        private bool LastSend(Coupler last)
        {
            last.Transmit(this);
            
            return true;
        }
    }
}