using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public abstract class TweenAnimation : MonoBehaviour
    {
        [SerializeField] private bool initOnAwake;

        protected virtual void Awake()
        {
            if(initOnAwake)
                Init();
        }

        public abstract void Init();

        public Tween Animation { get; protected set; }
    }
}