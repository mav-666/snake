using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public abstract class SingleAnimation : TweenAnimation
    {
        [SerializeField] private float duration;
        [SerializeField] private Ease ease;


        public override void Init()
        {
            Animation = CreateAnimation(duration).Pause().SetEase(ease).SetRelative().SetAutoKill(false);
        }

        protected abstract Tween CreateAnimation(float duration);
    }
}