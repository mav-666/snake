using DG.Tweening;
using Graphic.Animation;
using UnityEngine;

namespace Electricity
{
    public class AnimationOnSignal : MonoBehaviour, ISignalExecutor
    {
        [SerializeField] private TweenAnimation animation;
        
        public void ExecuteOn()
        {
            animation.Animation.Play();
        }

        public void ExecuteOff()
        {
            animation.Animation.PlayBackwards();
        }
    }
}