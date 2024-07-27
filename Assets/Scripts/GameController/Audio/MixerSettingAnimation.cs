using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.Audio;

namespace GameController.Audio
{
    public class MixerSettingAnimation : SingleAnimation
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private string settingName;
        [SerializeField] private float endValue;
        
        protected override Tween CreateAnimation(float duration)
        {
            return audioMixer.DOSetFloat(settingName, endValue, duration);
        }
    }
}