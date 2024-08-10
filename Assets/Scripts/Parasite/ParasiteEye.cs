using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Parasite
{
    [RequireComponent(typeof(ConeSensor))]
    public class ParasiteEye : OpeningEye
    {
        [SerializeField] private Light2D light2d;
        [SerializeField] private float duration;

        private bool _hasTarget;
        
        public event Action<bool> OnObserve;
        
        private ConeSensor _coneSensor;
        private Color _lightColor;
        private Tween _temp;
        private bool _isOpen;


        public event Action OnClose;
        
        private void Awake()
        {
            _lightColor = light2d.color;
            _coneSensor = GetComponent<ConeSensor>();
        }

        public override void Open()
        {
            _temp?.Kill();
            light2d.enabled = true;
            _isOpen = true;
            _temp = DOVirtual.Color(light2d.color, _lightColor, duration,
                value => light2d.color = value).SetEase(Ease.Linear);
            base.Open();
            
        }

        public override void Close()
        {
            _temp?.Kill();
            _isOpen = false;
            _temp = DOVirtual.Color(light2d.color, Color.clear, duration,
                value => light2d.color = value).OnComplete(CloseComplete).SetEase(Ease.Linear);
            base.Close();
        }
        
        private void CloseComplete()
        {
            light2d.enabled = false;
            OnClose?.Invoke();
        }
        
        private void Update()
        {
            if(_isOpen && _coneSensor.Check(out _))
                FoundTarget();
            else
                LostTarget();
        }

        private void FoundTarget()
        {
            if(_hasTarget)
                return;

            _hasTarget = true;
            OnObserve?.Invoke(true);
        }

        private void LostTarget()
        {
            if (!_hasTarget)
                return;
            
            _hasTarget = false;
            OnObserve?.Invoke(false);
        }
    }
}