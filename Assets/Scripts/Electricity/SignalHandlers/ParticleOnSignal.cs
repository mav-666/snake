using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class ParticleOnSignal : SignalExecutor
    {
        [SerializeField] private ParticleSystem on;
        [SerializeField] private ParticleSystem off;

        private bool _hasOn;
        private bool _hasOff;
        
        private void Awake()
        {
            _hasOn = on != null;
            _hasOff = off != null;

        }

        public override void ExecuteOn()
        {
            if(_hasOn)
                on.Play();
        }

        public override void ExecuteOff()
        {
            if(_hasOff)
                off.Play();
        }
    }
}