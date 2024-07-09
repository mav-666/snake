using UnityEngine;
using UnityEngine.Audio;

namespace GameController.Audio
{
    public class MusicSoundPlayer : LoopSoundPlayer
    {
        [SerializeField] private AudioMixerGroup audioMixerGroup;

        private AudioMixerGroup _initialGroup;
        
        protected override void InitSound()
        {
            base.InitSound();
            _temp.spatialBlend = 0;
            _initialGroup = _temp.outputAudioMixerGroup;
            _temp.outputAudioMixerGroup = audioMixerGroup;
        }

        protected override void Release()
        {
            _temp.outputAudioMixerGroup = _initialGroup;
            _temp.spatialBlend = 1;
            base.Release();
        }
    }
}