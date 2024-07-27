using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public class MoveAnimation : SingleAnimation
    {
        [SerializeField] private Vector3 relativePoint;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.TransformPoint(relativePoint), 0.2f);
        }

        protected override Tween CreateAnimation(float duration)
        {
            return transform.DOLocalMove(relativePoint, duration).SetRelative();
        }
    }
}