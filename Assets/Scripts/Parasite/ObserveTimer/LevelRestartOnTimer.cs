using System.Collections;
using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class LevelRestartOnTimer : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private float delay;
        
        private ObserveTimer _observeTimer;
        
        private void Awake()
        {
            _observeTimer = GetComponent<ObserveTimer>();
        }

        private void OnEnable()
        {
            _observeTimer.OnReachEnd += Restart;
        }

        private void OnDisable()
        {
            _observeTimer.OnReachEnd -= Restart;
        }

        private void Restart()
        {
            StartCoroutine(DelayRestart());
        }

        private IEnumerator DelayRestart()
        {
            yield return new WaitForSeconds(delay);
            gameManager.RestartLevel();
        }
    }
}