using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Electricity.Couplers.Electrons
{
    public class Electron : MonoBehaviour
    {
        private Light2D _light;
        private Color _originalColor;

        protected virtual void Awake()
        {
            _light = GetComponentInChildren<Light2D>();
            _originalColor = _light.color;
        }

        protected void ResetColor()
        {
            _light.color = _originalColor;
        }
        
        public void Fade(Action complete)
        {
            DOVirtual.Color(_light.color, Color.clear, 0.8f,
                value => _light.color = value).SetEase(Ease.Flash, 5, 1).OnComplete(complete.Invoke);
        }
    }
}