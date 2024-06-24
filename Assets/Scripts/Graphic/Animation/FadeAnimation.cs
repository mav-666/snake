using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public class FadeAnimation : SingleAnimation
    {
        [SerializeField] private float endAlpha;
        
        private SpriteRenderer _sprite;

        protected override void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            base.Awake();
        }

        protected override Tween CreateAnimation(float duration)
        {
            return _sprite.DOFade(endAlpha, duration).Play();
        }
    }
}