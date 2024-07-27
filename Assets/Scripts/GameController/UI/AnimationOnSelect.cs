using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameController.UI
{
    public class AnimationOnSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private TweenAnimation tweenAnimation;
        
        public void OnSelect(BaseEventData eventData)
        {
            tweenAnimation.Animation.PlayForward();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            tweenAnimation.Animation.PlayBackwards();
        }
    }
}