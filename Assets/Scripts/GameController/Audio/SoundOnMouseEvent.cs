using UnityEngine;

namespace GameController.Audio
{
    [RequireComponent(typeof(SoundPlayer))]
    public class SoundOnMouseEvent : MonoBehaviour
    {
        private SoundPlayer _soundPlayer;

        private void Awake()
        {
            _soundPlayer = GetComponent<SoundPlayer>();
        }

        private void OnMouseDown()
        {
            _soundPlayer.On();
        }

        private void OnMouseUp()
        {
            _soundPlayer.Off();
        }
    }
}