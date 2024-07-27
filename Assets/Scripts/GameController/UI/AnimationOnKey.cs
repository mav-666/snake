using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameController.UI
{
    public class AnimationOnKey : MonoBehaviour
    {
        [SerializeField] private InputActionReference actionReference;
        [SerializeField] private TweenAnimation tweenAnimation;
        [SerializeField] private bool isBackwards;
        
        private void OnEnable()
        {
            actionReference.action.performed += Animation;
            actionReference.action.Enable();
        }

        private void OnDisable()
        {
            actionReference.action.performed -= Animation;
            actionReference.action.Disable();
        }
        
        private void Animation(InputAction.CallbackContext ctx)
        {
            if(isBackwards)
                tweenAnimation.Animation.PlayBackwards();
            else
                tweenAnimation.Animation.PlayForward();
        }
    }
}