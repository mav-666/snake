
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace GameController.Audio
{
    public abstract class SoundPlayer : MonoBehaviour
    {
        [SerializeField, HideInInspector] protected AudioSourcePool audioSourcePool;

        
#if UNITY_EDITOR
        private void OnValidate()
        {
            audioSourcePool = FindFirstObjectByType<AudioSourcePool>();
            EditorUtility.SetDirty(this);
        }
#endif

        public abstract void On();
        
        public abstract void Off();
    }
}