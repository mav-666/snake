using UnityEngine;

namespace Parasite
{
    public class OpeningEye : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        public virtual void Open()
        {
            animator.SetTrigger("trOpen");
        }
        
        public virtual void Close()
        {
            animator.SetTrigger("trClose");
        }
    }
}