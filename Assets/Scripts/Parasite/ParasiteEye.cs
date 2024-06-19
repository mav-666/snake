using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Parasite
{
    [RequireComponent(typeof(PowerSensor))]
    public class ParasiteEye : MonoBehaviour
    {
        [SerializeField] private Light2D light2d;
        [SerializeField] private float duration;
        
        private PowerSensor _powerSensor;
        
        private Color _lightColor;
        private Tween _temp;
        
        private void Awake()
        {
            _powerSensor = GetComponent<PowerSensor>();
            _lightColor = light2d.color;
        }
        
        private void OnEnable()
        {
            _powerSensor.OnPowerLevelAchieve += Open;
            _powerSensor.OnPowerLevelLose += Close;
        }
        
        private void OnDisable()
        {
            _powerSensor.OnPowerLevelAchieve -= Open;
            _powerSensor.OnPowerLevelLose -= Close;
        }

        protected virtual void Open()
        {
            _temp?.Kill();
            light2d.enabled = true;
            _temp = DOVirtual.Color(light2d.color, _lightColor, duration,
                value => light2d.color = value).SetEase(Ease.Linear);
        }

        protected virtual void Close()
        {
            _temp?.Kill();
            _temp = DOVirtual.Color(light2d.color, Color.clear, duration,
                value => light2d.color = value).OnComplete(() => light2d.enabled = false).SetEase(Ease.Linear);
        }

    }
}