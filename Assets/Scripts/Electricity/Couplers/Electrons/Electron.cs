using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Electricity.Couplers.Electrons
{
    public abstract class Electron : MonoBehaviour
    {
        private Light2D _light;
        private Color _originalColor;
        private Action _onFail;

        protected virtual void Awake()
        {
            _light = GetComponentInChildren<Light2D>();
            _originalColor = _light.color;
        }

        protected void Init(Action onFail, int shipID)
        {
            _light.color = _originalColor;
            gameObject.name = shipID.ToString();
            _onFail = onFail;
        }

        public void Fade()
        {
            Stop();
            DOVirtual.Color(_light.color, Color.clear, 0.8f,
                value => _light.color = value).SetEase(Ease.Flash, 5, 1).OnComplete(_onFail.Invoke);
        }

        protected abstract void Stop();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (gameObject.name == other.gameObject.name)
                Fade();
        }
    }
}