using System;
using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public class TweenAnimations : TweenAnimation
    {
        [SerializeField] private SingleAnimation[] animations;
        [SerializeField] private bool playOnStart;
        
        private void Start()
        {
            var sequence = DOTween.Sequence().Pause().SetAutoKill(false);

            foreach (var animation in animations)
                sequence.Join(animation.Animation);

            Animation = sequence;
            
            if(playOnStart)
                Play();
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