using DG.Tweening;
using UnityEngine;

namespace Graphic.Animation
{
    public abstract class TweenAnimation : MonoBehaviour
    {
        public Tween Animation { get; protected set; }
    }
}