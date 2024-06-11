using UnityEngine;

namespace Snake
{
    public interface IMobility
    {
        GameObject gameObject { get; }

        public bool CanNotMove { get; set; }
        
        public void MoveBy(Vector2 direction);
    }
}