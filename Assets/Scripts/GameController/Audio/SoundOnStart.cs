using UnityEngine;

namespace GameController.Audio
{
    [RequireComponent(typeof(SoundPlayer))]
    public class SoundOnStart : MonoBehaviour
    {
        private SoundPlayer _soundPlayer;
        
        private void Awake()
        {
            _soundPlayer = GetComponent<SoundPlayer>();
        }

        private void Start()
        {
            _soundPlayer.On();
        }
    }
}