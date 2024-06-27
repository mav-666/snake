using System.Collections;
using UnityEditor;
using UnityEngine;

namespace GameController
{
    public class SoundOnContact : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private AudioClip audioClip;
        
        [SerializeField, HideInInspector] private AudioSourcePool audioSourcePool;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            audioSourcePool = FindFirstObjectByType<AudioSourcePool>();
            EditorUtility.SetDirty(this);
        }
#endif
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((layerMask & (1 << other.gameObject.layer)) == 0)
                return;
            
            var temp = audioSourcePool.Get();
            temp.transform.SetParent(transform);
            temp.volume = 1;
            temp.pitch = Random.Range(0.9f, 1.1f);
            temp.transform.position = other.GetContact(0).point;
            temp.loop = false;
            temp.clip = audioClip;

            temp.Play();
            StartCoroutine(ReleaseAfterPlay(temp));
        }
        
        private IEnumerator ReleaseAfterPlay(AudioSource temp)
        {
            yield return new WaitForSeconds(temp.clip.length);
            
            temp.transform.position = Vector3.zero;
            audioSourcePool.Release(temp);
        }
    }
}