using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameController.UI
{
    public class AnimationOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TweenAnimation tweenAnimation;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            tweenAnimation.Animation.PlayForward();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tweenAnimation.Animation.PlayBackwards();
        }
    }
}