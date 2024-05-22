using Electricity.Couplers;
using UnityEngine;

namespace Electricity
{
    public class Transmitter : Electric
    {
        public override bool ReceiveSignal(Coupler sender)
        {
            base.ReceiveSignal(sender);
            
            Disconnect(sender);
            var isSent = SendSignal();
            Connect(sender);
            return isSent;
        }

        [ContextMenu("send signal")]
        private void CheckSend()
        {
            SendSignal();
        }
    }
}