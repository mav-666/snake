using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class DisableOnTimer : ObserveTimerHandler
    {
        [SerializeField] private GameObject obj;

        private bool _wasEnabled;
        
        protected override void OnStart(float leftTime)
        {
            _wasEnabled = obj.activeSelf;
            
            if (_wasEnabled)
                obj.SetActive(false);
        }

        protected override void OnEnd(float leftTime)
        {
            if (_wasEnabled)
                obj.SetActive(true);
        }
    }
}