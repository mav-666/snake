using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Electricity
{
    public class Lamp : MonoBehaviour, ISignalExecutor
    {
        [SerializeField] private Light2D light2d;

        private Color _lightColor;
        private void Start()
        {
            _lightColor = light2d.color;
            light2d.color = Color.clear;    
        }
        
        public void ExecuteOn()
        {
            DOVirtual.Color(light2d.color, _lightColor, 0.8f,
                value => light2d.color = value).SetEase(Ease.Flash, 5, 1);
        }

        public void ExecuteOff()
        {
            DOVirtual.Color(light2d.color, Color.clear, 0.8f,
                value => light2d.color = value).SetEase(Ease.Flash, 5, 1);
        }
    }
}