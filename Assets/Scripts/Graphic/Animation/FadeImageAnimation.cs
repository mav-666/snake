using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Graphic.Animation
{
    public class FadeImageAnimation : SingleAnimation
    {
        [SerializeField] private float endAlpha;
        [SerializeField] private Image image;
        
        protected override Tween CreateAnimation(float duration)
        {
            return image.DOFade(endAlpha, duration).Play();
        }
    }
}