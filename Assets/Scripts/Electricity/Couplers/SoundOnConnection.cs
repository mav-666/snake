using System.Collections;
using GameController;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Electricity.Couplers
{
    [RequireComponent(typeof(FindingCoupler))]
    public class SoundOnConnection : MonoBehaviour
    {
        [SerializeField] private AudioClip[] connectSounds;
        [SerializeField] private AudioClip[] disconnectSounds;

        [SerializeField] private Transform targetA;
        [SerializeField] private Transform targetB;
        
        [SerializeField, HideInInspector] private AudioSourcePool audioSourcePool;

        private FindingCoupler _findingCoupler;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            audioSourcePool = FindFirstObjectByType<AudioSourcePool>();
            EditorUtility.SetDirty(this);
        }
#endif

        private void Awake()
        {
            _findingCoupler = GetComponent<FindingCoupler>();
        }

        private void OnEnable()
        {
            _findingCoupler.OnConnect += ConnectSound;
            _findingCoupler.OnDisconnect += DisconnectSound;
        }
        
        private void OnDisable()
        {
            _findingCoupler.OnConnect -= ConnectSound;
            _findingCoupler.OnDisconnect -= DisconnectSound;
        }

        private void ConnectSound(Order order)
        {
            var temp = audioSourcePool.Get();
            
            Transform trans;
            (trans = temp.transform).SetParent(order == Order.A ? targetA : targetB);
            trans.localPosition = Vector3.zero;
            
            temp.volume = 1;
            temp.pitch = Random.Range(0.9f, 1.1f);
            temp.loop = false;
            temp.clip = connectSounds[Random.Range(0, connectSounds.Length)];;

            temp.Play();
            StartCoroutine(ReleaseAfterPlay(temp));
        }
        
        private void DisconnectSound(Order order)
        {
            var temp = audioSourcePool.Get();
            
            Transform trans;
            (trans = temp.transform).SetParent(order == Order.A ? targetA : targetB);
            trans.localPosition = Vector3.zero;
            
            temp.volume = 1;
            temp.pitch = Random.Range(0.9f, 1.1f);
            temp.loop = false;
            temp.clip = disconnectSounds[Random.Range(0, disconnectSounds.Length)];

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