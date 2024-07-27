using DG.Tweening;

namespace Graphic.Animation
{
    public class IdleAnimation : SingleAnimation
    {
        protected override Tween CreateAnimation(float duration)
        {
            return DOVirtual.DelayedCall(duration,() => {});
        }
    }
}