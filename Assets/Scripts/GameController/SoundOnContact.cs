using UnityEngine;

namespace GameController
{
    [RequireComponent(typeof(SoundPlayer))]
    public class SoundOnContact : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;

        private SoundPlayer _soundPlayer;

        private void Awake()
        {
            _soundPlayer = GetComponent<SoundPlayer>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((layerMask & (1 << other.gameObject.layer)) == 0)
                return;
            
            _soundPlayer.On();
        }
    }
}