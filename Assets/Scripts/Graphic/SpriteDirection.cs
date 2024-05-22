using UnityEngine;

namespace Graphic
{
    public class SpriteDirection : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat("PosX", transform.parent.forward.x);
            _animator.SetFloat("PosY", transform.parent.forward.y);
        }
    }
}