using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public class FadeAnimation : SingleAnimation
    {
        [SerializeField] private float endAlpha;
        [SerializeField] private SpriteRenderer sprite;
        
        protected override Tween CreateAnimation(float duration)
        {
            return sprite.DOFade(endAlpha, duration).Play();
        }
    }
}