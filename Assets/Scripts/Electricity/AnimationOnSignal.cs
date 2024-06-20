using DG.Tweening;
using Graphic.Animation;
using UnityEngine;

namespace Electricity
{
    public class AnimationOnSignal : MonoBehaviour, ISignalExecutor
    {
        [SerializeField] private TweenAnimation tweenAnimation;
        
        public void ExecuteOn()
        {
            tweenAnimation.Animation.PlayForward();
        }

        public void ExecuteOff()
        {
            tweenAnimation.Animation.PlayBackwards();
        }
    }
}