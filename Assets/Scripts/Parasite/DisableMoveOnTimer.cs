using Snake;
using UnityEngine;

namespace Parasite
{
    public class DisableMoveOnTimer : MonoBehaviour
    {
        [SerializeField] private SnakeAdapter mobility;

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
            mobility.CanNotMove = true;
        } 
    }
}