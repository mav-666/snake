using DG.Tweening;
using UnityEngine;

namespace Parasite
{
    public class ColorOnTimer : ObserveTimerHandler
    {
        [SerializeField] private SpriteRenderer[] sprites;
        [SerializeField] private Color endColor;
        
        private Color _startColor;

        private void Start()
        {
            _startColor = sprites[0].color;
        }

        protected override void OnStart(float leftTime)
        {
            foreach (var sprite in sprites)
            {
                DOTween.Kill(sprite);
                sprite.DOColor(endColor, leftTime);
            }
        }

        protected override void OnEnd(float leftTime)
        {
            foreach (var sprite in sprites)
            {
                DOTween.Kill(sprite);
                sprite.DOColor(_startColor, leftTime);
            }
        }
        
    }
}