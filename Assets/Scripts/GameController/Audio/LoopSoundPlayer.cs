using DG.Tweening;
using UnityEngine;

namespace GameController.Audio
{
    public class LoopSoundPlayer : SoundPlayer
    {
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private float volume = 1;

        protected AudioSource _temp;
        private bool _isPlaying;
        
        public override void On()
        {
            if(_isPlaying)
                return;
            
            InitSound();
            _isPlaying = true;
            
            _temp.Play();
            _temp.DOFade(volume, 0.3f);
        }

        protected virtual void InitSound()
        {
            _temp = audioSourcePool.Get();
            _temp.volume = 0;
            _temp.pitch = 1;
            _temp.loop = true;
            _temp.clip = audioClip;
            _temp.time = Random.Range(0f, audioClip.length);
            
            Transform trans;
            (trans = _temp.transform).SetParent(transform);
            trans.localPosition = Vector3.zero;
        }
        

        public override void Off()
        {
            if(!_isPlaying)
                return;

            _temp.DOFade(0, 0.3f).OnComplete(Release);
        }

        protected virtual void Release()
        {
            _isPlaying = false;
            _temp.Stop();
            audioSourcePool.Release(_temp);
        }
    }
}