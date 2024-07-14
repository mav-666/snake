using UnityEngine;
using UnityEngine.Audio;

namespace GameController.Audio
{
    public class MusicSoundPlayer : LoopSoundPlayer
    {
        private static bool _isPlaying;
        
        [SerializeField] private AudioMixerGroup audioMixerGroup;

        private AudioMixerGroup _initialGroup;

        private void Awake()
        {
            if(_isPlaying)
                return;
            
            transform.SetParent(transform.root.parent);
            DontDestroyOnLoad(this);
        }

        public override void On()
        {
            if(_isPlaying)
                return;
            
            _isPlaying = true;
            base.On();
        }

        public override void Off()
        {
            _isPlaying = false;
            base.Off();
        }

        protected override void InitSound()
        {
            base.InitSound();
            _initialGroup = _temp.outputAudioMixerGroup;
            _temp.outputAudioMixerGroup = audioMixerGroup;
        }

        protected override void Release()
        {
            _temp.outputAudioMixerGroup = _initialGroup;
            base.Release();
        }
    }
}