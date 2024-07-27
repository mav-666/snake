using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public class RotateAnimation : SingleAnimation
    {
        [SerializeField] private float angleStart;
        [SerializeField] private float angleEnd;
        
        public override void Init()
        {
            base.Init();
            transform.localRotation = Quaternion.Euler(0,0,angleStart);
        }

        protected override Tween CreateAnimation(float duration)
        {
            return transform.DOLocalRotate(new Vector3(0,0, angleEnd), duration).From(new Vector3(0,0,angleStart)).SetRelative();
        }
    }
}