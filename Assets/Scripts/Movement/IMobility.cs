using UnityEngine;

namespace Movement
{
    public interface IMobility
    {
        GameObject gameObject { get; }

        public bool CanNotMove { set; }

        public void MoveBy(Vector2 direction);
    }
}