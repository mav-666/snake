using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

namespace GameController.Audio
{
    public class LoopSoundPlayer : SoundPlayer
    {
        [SerializeField] protected AudioClip audioClip;
        [SerializeField] private float volume = 1;

        [SerializeField] private float fadeInDuration = 0.3f;
        [SerializeField] private float fadeOutDuration = 0.3f;
        
        [SerializeField] private AudioMixerGroup audioMixerGroup;

        [SerializeField] private bool isMono;

        protected AudioSource _temp;
        
        private AudioMixerGroup _initialGroup;

        private bool _isPlaying;
        
        public override void On()
        {
            if(_isPlaying)
                return;
            
            InitSound();
            _isPlaying = true;
            
            _temp.Play();
            _temp.DOFade(volume, fadeInDuration);
        }

        protected virtual void InitSound()
        {
            _temp = audioSourcePool.Get();
            _temp.volume = 0;
            _temp.pitch = 1;
            _temp.loop = true;
            _temp.clip = audioClip;
            _temp.time = Random.Range(0f, audioClip.length);
            
            _initialGroup = _temp.outputAudioMixerGroup;
            _temp.outputAudioMixerGroup = audioMixerGroup;

            if (isMono)
                _temp.spatialBlend = 0;

            Transform trans;
            (trans = _temp.transform).SetParent(transform);
            trans.localPosition = Vector3.zero;
        }
        

        public override void Off()
        {
            if(!_isPlaying)
                return;

            _temp.DOFade(0, fadeOutDuration).OnComplete(Release);
        }

        protected virtual void Release()
        {
            _isPlaying = false;
            _temp.Stop();
            
            _temp.outputAudioMixerGroup = _initialGroup;
            
            if(isMono)
                _temp.spatialBlend = 1;
            
            audioSourcePool.Release(_temp);
        }
        
        
    }
}