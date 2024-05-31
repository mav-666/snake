
using UnityEngine;
using UnityEngine.Rendering.Universal;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Parasite
{
    [RequireComponent(typeof(FlashlightSensor))]
    public class LightByFlashlightSensor : MonoBehaviour
    {
        [SerializeField] private Light2D light2d;
        
        private FlashlightSensor _flashlight;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _flashlight = GetComponent<FlashlightSensor>();

            light2d.pointLightInnerRadius = _flashlight.Radius;
            light2d.pointLightOuterRadius = _flashlight.Radius + 0.2f;
            
            light2d.pointLightInnerAngle = _flashlight.ObserveAngle;
            light2d.pointLightOuterAngle = _flashlight.ObserveAngle + 20;
            
            EditorUtility.SetDirty(light2d);
        }  
#endif
    }
}