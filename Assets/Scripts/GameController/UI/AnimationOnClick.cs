using DG.Tweening;
using Graphic.Animation;
using UnityEngine;
using UnityEngine.UI;

namespace GameController.UI
{
    public class AnimationOnClick : MonoBehaviour
    {
        [SerializeField] private TweenAnimation tween;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(PlayAnimation);
        }

        private void PlayAnimation()
        {
            tween.Animation.PlayForward();
        }
    }
}