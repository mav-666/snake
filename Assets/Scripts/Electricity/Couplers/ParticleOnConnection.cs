using UnityEngine;

namespace Electricity.Couplers
{
    public class ParticleOnConnection : MonoBehaviour
    {
        [SerializeField] private FindingCoupler findingCoupler;
        
        [SerializeField] private ParticleSystem connectParticle;
        [SerializeField] private ParticleSystem disconnectParticle;

        [SerializeField] private Transform sourceA;
        [SerializeField] private Transform sourceB;
        
        private void OnEnable()
        {
            findingCoupler.OnConnect += ConnectParticle;
            findingCoupler.OnDisconnect += DisconnectParticle;
        }
        
        private void OnDisable()
        {
            findingCoupler.OnConnect -= ConnectParticle;
            findingCoupler.OnDisconnect -= DisconnectParticle;
        }

        private void ConnectParticle(Order order)
        {
            connectParticle.transform.position = order == Order.A ? sourceA.position : sourceB.position;
            connectParticle.Play();
        }
        
        private void DisconnectParticle(Order order)
        {
            disconnectParticle.transform.position = order == Order.A ? sourceA.position : sourceB.position;
            disconnectParticle.Play();
        }
    }
}