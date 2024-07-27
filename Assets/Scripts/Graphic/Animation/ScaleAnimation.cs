using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public class ScaleAnimation : SingleAnimation
    {
        [SerializeField] private float relativeScale;
        
        protected override Tween CreateAnimation(float duration)
        {
            return transform.DOScale(relativeScale, duration).SetRelative();
        }
    }
}