using GameController.Audio;
using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class SoundOnTimer : ObserveTimerHandler
    {
        [SerializeField] private SoundPlayer soundPlayer;
        
        protected override void OnStart(float leftTime)
        {
            soundPlayer.On();
        }

        protected override void OnEnd(float leftTime)
        {
            soundPlayer.Off();
        }

        protected override void OnReachEnd()
        {
            soundPlayer.Off();
            base.OnReachEnd();
        }
    }
}