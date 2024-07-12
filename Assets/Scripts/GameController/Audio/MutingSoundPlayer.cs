using UnityEngine;

namespace GameController.Audio
{
    public class MutingSoundPlayer : SingleSoundPlayer
    {
        private bool _isPlaying;
        
        public override void On()
        {
            if (_isPlaying)
                _temp.volume = 0;
            
            _isPlaying = true;
            base.On();
        }
        
        public override void Off()
        {
            if (_isPlaying)
                _temp.volume = 0;

            _isPlaying = true;
            base.On();
        }
        
        protected override void Release(AudioSource temp)
        {
            if (temp.volume != 0)
                _isPlaying = false;
            
            base.Release(temp);
        }
    }
}