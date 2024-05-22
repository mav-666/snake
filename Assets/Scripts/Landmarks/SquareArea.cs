using UnityEngine;

namespace Landmarks
{
    public class SquareArea : Area
    {

        [SerializeField] private Vector2 squareSize;
        
        private void OnDrawGizmos()
        {
            var trans = transform;
            
            Gizmos.color = Color.yellow;
            Gizmos.matrix = Matrix4x4.TRS(trans.position, trans.rotation, trans.lossyScale);
            
            Gizmos.DrawWireCube(Vector3.zero, squareSize);
        }

        public override bool IsInside(Vector3 point)
        {
            var trans = transform;
            
            var localSize = squareSize;
            var localPos = trans.position - point;
            var rotation = trans.rotation;

            localPos = rotation * localPos;
            localSize = rotation * localSize;
            
            var halfX = localSize.x * 0.5f;
            var halfY = localSize.y * 0.5f;

            return localPos.x < halfX && localPos.x > -halfX 
                && localPos.y < halfY && localPos.y > -halfY;

        }
    }
}