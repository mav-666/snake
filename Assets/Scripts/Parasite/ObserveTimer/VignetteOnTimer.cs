using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Parasite.ObserveTimer
{
    public class VignetteOnTimer : ObserveTimerHandler
    {
        [SerializeField] private Volume volume;
        [SerializeField] private float endIntensity;

        private Vignette _vignette;
        private float _startIntensity;
        private Tweener _temp;
        
        private void Start()
        {
            volume.profile.TryGet(out _vignette);
            _startIntensity = _vignette.intensity.value;
        }
        
        protected override void OnStart(float leftTime)
        {
            _temp?.Kill();
            _temp = DOVirtual.Float(_startIntensity, endIntensity, leftTime,
                value => _vignette.intensity.value = value);
        }

        protected override void OnEnd(float leftTime)
        {
            _temp?.Kill();
            _temp = DOVirtual.Float(endIntensity, _startIntensity, leftTime,
                value => _vignette.intensity.value = value);
        }
    }
}