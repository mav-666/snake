using GameController;
using UnityEngine;

namespace Electricity.Couplers
{
    [RequireComponent(typeof(FindingCoupler))]
    public class SoundOnConnection : MonoBehaviour
    {
        [SerializeField] private SoundPlayer soundPlayerA;
        [SerializeField] private SoundPlayer soundPlayerB;

        private FindingCoupler _findingCoupler;
        
        private void Awake()
        {
            _findingCoupler = GetComponent<FindingCoupler>();
        }

        private void OnEnable()
        {
            _findingCoupler.OnConnect += ConnectSound;
            _findingCoupler.OnDisconnect += DisconnectSound;
        }
        
        private void OnDisable()
        {
            _findingCoupler.OnConnect -= ConnectSound;
            _findingCoupler.OnDisconnect -= DisconnectSound;
        }

        private void ConnectSound(Order order)
        {
            if(order == Order.A)
                soundPlayerA.On();
            else 
                soundPlayerB.On();
        }
        
        private void DisconnectSound(Order order)
        {
            if(order == Order.A)
                soundPlayerA.Off();
            else 
                soundPlayerB.Off();
        }
    }
}