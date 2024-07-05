using System.Collections;
using UnityEngine;

namespace GameController
{
    public class SingleSoundPlayer : SoundPlayer
    {
        [SerializeField] private AudioClip[] onSounds;
        [SerializeField] private AudioClip[] offSounds;
        
        public override void On()
        {
            var temp = audioSourcePool.Get();
      
            Transform trans;
            (trans = temp.transform).SetParent(transform);
            trans.localPosition = Vector3.zero;
            
            temp.volume = 1;
            temp.pitch = Random.Range(0.9f, 1.1f);
            temp.loop = false;
            
            temp.clip = onSounds[Random.Range(0, onSounds.Length)];

            temp.Play();
            StartCoroutine(ReleaseAfterPlay(temp));
        }

        public override void Off()
        {
            var temp = audioSourcePool.Get();
            
            Transform trans;
            (trans = temp.transform).SetParent(transform);
            trans.localPosition = Vector3.zero;
            
            temp.volume = 1;
            temp.pitch = Random.Range(0.9f, 1.1f);
            temp.loop = false;
            temp.clip = offSounds[Random.Range(0, offSounds.Length)];

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