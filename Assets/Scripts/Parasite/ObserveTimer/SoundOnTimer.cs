using GameController;

namespace Parasite.ObserveTimer
{
    public class SoundOnTimer : ObserveTimerHandler
    {
        private SoundPlayer _soundPlayer;

        protected override void Awake()
        {
            _soundPlayer = GetComponent<SoundPlayer>();
        }
        
        protected override void OnStart(float leftTime)
        {
            _soundPlayer.On();
        }

        protected override void OnEnd(float leftTime)
        {
            _soundPlayer.Off();
        }
    }
}