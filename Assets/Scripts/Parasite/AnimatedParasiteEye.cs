using DG.Tweening;
using Graphic.Animation;
using UnityEngine;

namespace Parasite
{
    public class AnimatedParasiteEye : ParasiteEye
    {
        [SerializeField] private TweenAnimation anim;

        private void Start()
        {
            anim.Animation.SetLoops(-1, LoopType.Yoyo);
        }

        protected override void Open()
        {
            base.Open();
            anim.Animation.Play();
        }

        protected override void Close()
        {
            base.Close();
            anim.Animation.Pause();
        }
    }
}