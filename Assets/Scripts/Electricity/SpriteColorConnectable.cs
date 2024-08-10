using DG.Tweening;
using Graphic.Animation;
using UnityEngine;

namespace Electricity
{
    public class SpriteColorConnectable : Connectable
    {
        [SerializeField] private TweenAnimation tweenAnimation;
        
        public override void Select()
        {
            tweenAnimation.Animation.PlayForward();
        }

        public override void Deselect()
        {
            tweenAnimation.Animation.PlayBackwards();
        }
    }
}