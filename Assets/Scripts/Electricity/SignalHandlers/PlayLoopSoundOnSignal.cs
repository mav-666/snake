using DG.Tweening;
using GameController;
using UnityEditor;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class PlayLoopSoundOnSignal : SignalExecutor
    {
        [SerializeField] private AudioClip audioClip;
        
        [SerializeField, HideInInspector] private AudioSourcePool audioSourcePool;
        
        private AudioSource _temp;
        
        private bool _isPlaying;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            audioSourcePool = FindFirstObjectByType<AudioSourcePool>();
            EditorUtility.SetDirty(this);
        }
#endif
        
        public override void ExecuteOn()
        {
            _temp = audioSourcePool.Get();
            _temp.volume = 0;
            _temp.pitch = 1;
            _temp.loop = true;
            _temp.clip = audioClip;
            _temp.transform.SetParent(transform);
            _isPlaying = true;
            
            _temp.Play();
            _temp.DOFade(1, 0.3f);
        }

        public override void ExecuteOff()
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