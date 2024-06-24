using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public class SequenceAnimation : TweenAnimation
    {
        [SerializeField] private TweenAnimation[] animations;
        [SerializeField] private bool playOnStart;
        
        private void Start()
        {
            if(playOnStart)
                Play();
        }

        public override void Init()
        {
            var sequence = DOTween.Sequence().Pause().SetAutoKill(false);

            foreach (var animation in animations)
            {
                animation.Init();
                sequence.Append(animation.Animation);
            }
            
            Animation = sequence;
        }

        [ContextMenu("play")]
        public void Play()
        {
            Animation.PlayForward();
        }

        [ContextMenu("reversePlay")]
        public void ReversePlay()
        {
            Animation.PlayBackwards();
        }
    }
}