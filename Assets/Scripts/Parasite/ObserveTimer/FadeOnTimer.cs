using DG.Tweening;
using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class FadeOnTimer : ObserveTimerHandler
    {
        [SerializeField] private SpriteRenderer[] sprites;
        [SerializeField] private float endAlpha;
        
        private float _startAlpha;

        private void Start()
        {
            _startAlpha = sprites[0].color.a;
        }

        protected override void OnStart(float leftTime)
        {
            foreach (var sprite in sprites)
            {
                DOTween.Kill(sprite);
                sprite.DOFade(endAlpha, leftTime);
            }
        }

        protected override void OnEnd(float leftTime)
        {
            foreach (var sprite in sprites)
            {
                DOTween.Kill(sprite);
                sprite.DOFade(_startAlpha, leftTime);
            }
        }
    }
}