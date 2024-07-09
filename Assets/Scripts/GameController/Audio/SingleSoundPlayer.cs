using System.Collections;
using SneakySquirrelLabs.MinMaxRangeAttribute;
using UnityEngine;

namespace GameController.Audio
{
    public class SingleSoundPlayer : SoundPlayer
    {
        [SerializeField] private AudioClip[] onSounds;
        [SerializeField] private AudioClip[] offSounds;

        [SerializeField, MinMaxRange(0f, 2f)] private Vector2 pitchOn = new (0.9f, 1.1f);
        [SerializeField, MinMaxRange(0f, 2f)] private Vector2 pitchOff = new (0.9f, 1.1f);
        
        public override void On()
        {
            var temp = audioSourcePool.Get();
      
            Transform trans;
            (trans = temp.transform).SetParent(transform);
            trans.localPosition = Vector3.zero;
            
            temp.volume = 1;
            temp.pitch = Random.Range(pitchOn.x, pitchOn.y);
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
            temp.pitch = Random.Range(pitchOff.x, pitchOff.y);
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