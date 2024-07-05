using DG.Tweening;
using UnityEngine;

namespace GameController
{
    public class LoopSoundPlayer : SoundPlayer
    {
        [SerializeField] private AudioClip audioClip;

        private AudioSource _temp;
        private bool _isPlaying;
        
        public override void On()
        {
            _temp = audioSourcePool.Get();
            _temp.volume = 0;
            _temp.pitch = 1;
            _temp.loop = true;
            _temp.clip = audioClip;
            
            Transform trans;
            (trans = _temp.transform).SetParent(transform);
            trans.localPosition = Vector3.zero;
            _isPlaying = true;
            
            _temp.Play();
            _temp.DOFade(1, 0.3f);
        }

        public override void Off()
        {
            if(!_isPlaying)
                return;

            _temp.DOFade(0, 0.3f).OnComplete(() =>
            {
                _isPlaying = false;
                _temp.Stop();
                audioSourcePool.Release(_temp);
            });
        }
    }
}