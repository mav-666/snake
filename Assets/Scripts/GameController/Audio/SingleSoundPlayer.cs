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

        protected AudioSource _temp;

        public override void On()
        {
            if(onSounds.Length == 0)
                return;
            
            _temp = audioSourcePool.Get();
      
            InitSound(true);

            _temp.Play();
            StartCoroutine(ReleaseCoroutine(_temp));
        }

        public override void Off()
        {
            if(offSounds.Length == 0)
                return;

            _temp = audioSourcePool.Get();
            
            InitSound(false);

            _temp.Play();
            StartCoroutine(ReleaseCoroutine(_temp));
        }

        protected virtual void InitSound(bool isOn)
        {
            Transform trans;
            (trans = _temp.transform).SetParent(transform);
            trans.localPosition = Vector3.zero;
            
            _temp.volume = 1;
            _temp.loop = false;
            
            if (isOn)
            {
                _temp.pitch = Random.Range(pitchOn.x, pitchOn.y);
                _temp.clip = onSounds[Random.Range(0, onSounds.Length)]; 
            }
            else
            {
                _temp.pitch = Random.Range(pitchOff.x, pitchOff.y);
                _temp.clip = offSounds[Random.Range(0, offSounds.Length)]; 
            }
        }
        
        private IEnumerator ReleaseCoroutine(AudioSource temp)
        {
            yield return new WaitForSeconds(temp.clip.length);
            
            Release(temp);
        }

        protected virtual void Release(AudioSource temp)
        {
            audioSourcePool.Release(temp);
        }
    }
}