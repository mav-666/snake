
using UnityEngine;
using UnityEngine.Rendering.Universal;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Parasite
{
    [RequireComponent(typeof(ConeSensor))]
    public class LightByConeSensor : MonoBehaviour
    {
        [SerializeField] private Light2D light2d;
        
        private ConeSensor _cone;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _cone = GetComponent<ConeSensor>();

            light2d.pointLightInnerRadius = _cone.Radius;
            light2d.pointLightOuterRadius = _cone.Radius + 0.2f;
            
            light2d.pointLightInnerAngle = _cone.ObserveAngle;
            light2d.pointLightOuterAngle = _cone.ObserveAngle + 20;
            
            EditorUtility.SetDirty(light2d);
        }  
#endif
    }
}