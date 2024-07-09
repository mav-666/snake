using GameController;
using GameController.Audio;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    [RequireComponent(typeof(SoundPlayer))]
    public class SoundOnSignal : SignalExecutor
    {
        private SoundPlayer _soundPlayer;

        private void Awake()
        {
            _soundPlayer = GetComponent<SoundPlayer>();
        }

        public override void ExecuteOn()
        {
            _soundPlayer.On();
        }
        
        public override void ExecuteOff()
        {
            _soundPlayer.Off();
        }
    }
}