using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public class ShakeAnimation : SingleAnimation
    {
        [SerializeField] private float strength = 1;
        [SerializeField] private int vibrato = 10;
        [SerializeField, Range(0, 180f)] private float randomness = 90f;
        
        protected override Tween CreateAnimation(float duration)
        {
            return transform.DOShakePosition(duration, strength, vibrato, randomness);
        }
    }
}