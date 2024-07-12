using System.Collections;
using UnityEngine;

namespace Electricity.Couplers
{
    public class CooldownOnDisconnect : MonoBehaviour
    {
        [SerializeField] private float delay;
        [SerializeField] private Order cause;
        
        private FindingCoupler _findingCoupler;

        private void Awake()
        {
            _findingCoupler = GetComponent<FindingCoupler>();
        }

        private void OnEnable()
        {
            _findingCoupler.OnDisconnect += DisableCoupler;
        }

        private void OnDisable()
        {
            _findingCoupler.OnDisconnect -= DisableCoupler;
        }

        private void DisableCoupler(Order order)
        {
            if (cause != Order.AB && cause != order)
                return;
            
            _findingCoupler.CanNotConnect = true;
            StartCoroutine(DisableCoroutine());
        }

        private IEnumerator DisableCoroutine()
        {
            yield return new WaitForSeconds(delay);
            
            _findingCoupler.CanNotConnect = false;
        }
    }
}