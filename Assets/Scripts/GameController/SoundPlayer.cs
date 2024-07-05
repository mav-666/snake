#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace GameController
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