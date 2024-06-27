using System.Collections;
using Electricity.Couplers.Electrons;
using GameController;
using UnityEditor;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class PlaySoundOnSignal : SignalExecutor
    {
        [SerializeField] private AudioClip on;
        [SerializeField] private AudioClip off;
        
        [SerializeField, HideInInspector] private AudioSourcePool audioSourcePool;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            audioSourcePool = FindFirstObjectByType<AudioSourcePool>();
            EditorUtility.SetDirty(this);
        }
#endif
        
        public override void ExecuteOn()
        {
            var temp = audioSourcePool.Get();
            temp.transform.SetParent(transform);
            temp.volume = 1;
            temp.pitch = Random.Range(0.9f, 1.1f);
            temp.loop = false;
            
            temp.clip = on;

            temp.Play();
            StartCoroutine(ReleaseAfterPlay(temp));
        }
        
        public override void ExecuteOff()
        {
            var temp = audioSourcePool.Get();
            temp.transform.SetParent(transform);
            temp.volume = 1;
            temp.pitch = Random.Range(0.9f, 1.1f);
            temp.loop = false;
            temp.clip = off;

            temp.Play();
            StartCoroutine(ReleaseAfterPlay(temp));
        }
        
        private IEnumerator ReleaseAfterPlay(AudioSource temp)
        {
            yield return new WaitForSeconds(temp.clip.length);
            
            audioSourcePool.Release(temp);
        }

    }
}