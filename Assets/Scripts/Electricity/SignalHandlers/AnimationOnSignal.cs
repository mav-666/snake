using DG.Tweening;
using Graphic.Animation;
using UnityEngine;

namespace Electricity.SignalHandlers
{
    public class AnimationOnSignal : SignalExecutor
    {
        [SerializeField] private TweenAnimation tweenAnimation;
        
        public override void ExecuteOn()
        {
            tweenAnimation.Animation.PlayForward();
        }

        public override void ExecuteOff()
        {
            tweenAnimation.Animation.PlayBackwards();
        }
    }
}