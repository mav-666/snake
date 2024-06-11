using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public abstract class SingleAnimation : TweenAnimation
    {
        [SerializeField] private float duration;
        [SerializeField] private Ease ease;
        
        private void Awake()
        {
            Animation = CreateAnimation(duration).Pause().SetEase(ease).SetRelative().SetAutoKill(false);
        }
        
        protected abstract Tween CreateAnimation(float duration);
    }
}