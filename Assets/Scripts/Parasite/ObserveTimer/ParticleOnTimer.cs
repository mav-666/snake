using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class ParticleOnTimer : ObserveTimerHandler
    {
        [SerializeField] private ParticleSystem particle;
        
        protected override void OnStart(float leftTime)
        {
            particle.Play();
        }

        protected override void OnEnd(float leftTime)
        {
            particle.Stop();
        }
    }
}