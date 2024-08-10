
using System;
using DG.Tweening;
using Graphic.Animation;
using Snake;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameController.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private InputActionReference actionReference;
        [SerializeField] private InputActionAsset actions;
        [SerializeField] private TweenAnimation tweenAnimation;
        [SerializeField] private GameObject panel;

        private InputActionMap _playerMap;
        private bool _isPaused;

        private void Awake()
        {
            _playerMap = actions.FindActionMap("Player");
        }

        private void Start()
        {
            tweenAnimation.Animation.SetUpdate(true);
        }

        private void OnEnable()
        {
            actionReference.action.performed += Pause;
            actionReference.action.Enable();
        }

        private void OnDisable()
        {
            actionReference.action.performed -= Pause;
            actionReference.action.Disable();
        }

        private void Pause(InputAction.CallbackContext ctx)
        {
            if(_isPaused)
                Unpause();
            else 
                Pause();

        }

        public void Pause()
        {
            _isPaused = true;
            _playerMap.Disable();
            panel.SetActive(true);
            
            tweenAnimation.Animation.OnComplete(() => SetTimeScale(0)).PlayForward();
        }

        private void SetTimeScale(float scale)
        {
            Time.timeScale = scale;
        }
        
        public void Unpause()
        {
            _isPaused = false;
            SetTimeScale(1);
            
            
            tweenAnimation.Animation.OnRewind(() =>
            {
                _playerMap.Enable();
                panel.SetActive(false);
            }).PlayBackwards();
        }
    }
}