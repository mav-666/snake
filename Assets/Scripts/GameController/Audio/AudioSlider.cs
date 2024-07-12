using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace GameController.Audio
{
    public class AudioSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private string settingName;
        
        private Slider _slider;
        
        private void Awake()
        {
            _slider.GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.onValueChanged.AddListener(SetVolume);

            if(PlayerPrefs.HasKey(settingName))
                LoadVolume();
                    
            SetVolume(_slider.value);
        }

        private void LoadVolume()
        {
            _slider.value = PlayerPrefs.GetFloat(settingName);
        }
        
        private void SetVolume(float value)
        {
            audioMixer.SetFloat(settingName, MathF.Log10(value) * 20);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat(settingName, _slider.value);
        }
    }
}