using Electricity.Couplers;
using UnityEngine;

namespace Electricity
{
    public class Transmitter : Electric
    {
        public const float ConnectingDistance = 3f;

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
        
        private void OnDrawGizmosSelected()
        {
            if (!CompareTag("Cord"))
                return;
            
            Gizmos.color = Color.green;
            foreach (var cord in GameObject.FindGameObjectsWithTag("Cord"))
            {
                if(Vector3.Distance(cord.transform.position, transform.position) > ConnectingDistance)
                    continue;
                
                Gizmos.DrawLine(transform.position, cord.transform.position);
            }
        }

        [ContextMenu("distance")]
        private void CheckDistance()
        {
            foreach (var cord in GameObject.FindGameObjectsWithTag("Cord"))
                    Debug.Log($"{name} - {cord.name} = {Vector3.Distance(cord.transform.position, transform.position)}");
        }
        
    }
}