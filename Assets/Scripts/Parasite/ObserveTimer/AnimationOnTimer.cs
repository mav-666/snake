using System.Collections;
using DG.Tweening;
using Graphic.Animation;
using UnityEngine;

namespace Parasite.ObserveTimer
{
    public class AnimationOnTimer : MonoBehaviour
    {
        [SerializeField] private TweenAnimation tweenAnimation;
        [SerializeField] private float delay;
        
        private ObserveTimer _observeTimer;
        
        private void Awake()
        {
            _observeTimer = GetComponent<ObserveTimer>();
        }

        private void OnEnable()
        {
            _observeTimer.OnReachEnd += PlayAnimation;
        }

        private void OnDisable()
        {
            _observeTimer.OnReachEnd -= PlayAnimation;
        }

        private void PlayAnimation()
        {
            StartCoroutine(DelayPlayAnimation());
        }

        private IEnumerator DelayPlayAnimation()
        {
            yield return new WaitForSeconds(delay);
            tweenAnimation.Animation.PlayForward();
        }
    }
}