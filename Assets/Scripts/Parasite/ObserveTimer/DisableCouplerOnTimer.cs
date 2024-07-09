using Electricity.Couplers;
using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class DisableCouplerOnTimer : MonoBehaviour
    {
        [SerializeField] private FindingCoupler coupler;

        private ObserveTimer _observeTimer;

        private void Awake()
        {
            _observeTimer = GetComponent<ObserveTimer>();
        }

        private void OnEnable()
        {
            _observeTimer.OnReachEnd += DisableInput;
        }

        private void OnDisable()
        {
            _observeTimer.OnReachEnd -= DisableInput;
        }

        private void DisableInput()
        {
            coupler.CanNotConnect = true;
        } 
    }
}