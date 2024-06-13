using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Electricity
{
    public class Lamp : MonoBehaviour, ISignalExecutor
    {
        [SerializeField] private LampConfig lampConfig;
        [SerializeField] private Light2D light2d;

        private Color _lightColor;
        
        private void Start()
        {
            _lightColor = light2d.color;
            light2d.enabled = false;
            light2d.color = Color.clear;    
        }
        
        public void ExecuteOn()
        {
            light2d.enabled = true;
            DOVirtual.Color(light2d.color, _lightColor, lampConfig.duration,
                value => light2d.color = value).SetEase(Ease.Flash, lampConfig.amplitude, lampConfig.period);
        }

        public void ExecuteOff()
        {
            DOVirtual.Color(light2d.color, Color.clear, lampConfig.duration,
                value => light2d.color = value).OnComplete(() => light2d.enabled = false).SetEase(Ease.Flash, lampConfig.amplitude, lampConfig.period);
        }
    }
}