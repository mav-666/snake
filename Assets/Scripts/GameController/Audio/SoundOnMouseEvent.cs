using UnityEngine;
using UnityEngine.EventSystems;

namespace GameController.Audio
{
    [RequireComponent(typeof(SoundPlayer))]
    public class SoundOnMouseEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private SoundPlayer _soundPlayer;

        private void Awake()
        {
            _soundPlayer = GetComponent<SoundPlayer>();
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _soundPlayer.On();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _soundPlayer.Off();
        }
    }
}