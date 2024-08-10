using UnityEngine;

namespace Electricity
{
    [RequireComponent(typeof(Electric))]
    public abstract class Connectable : MonoBehaviour
    {
        public const float ConnectingDistance = 3f;
        
        public Electric Electric { get; private set; }

        private void Awake()
        {
            Electric = GetComponent<Electric>();
        }

        public abstract void Select();
        
        public abstract void Deselect();
        
        private void OnDrawGizmosSelected()
        {
            if (!CompareTag("Cord"))
                return;
            
            Gizmos.color = Color.green;
            foreach (var cord in GameObject.FindGameObjectsWithTag("Cord"))
            {
                if(Vector3.Distance(cord.transform.position, transform.position) > ConnectingDistance)
                    continue;
                
                Gizmos.DrawLine(transform.position, cord.transform.position);
            }
        }

        [ContextMenu("distance")]
        private void CheckDistance()
        {
            foreach (var cord in GameObject.FindGameObjectsWithTag("Cord"))
                Debug.Log($"{name} - {cord.name} = {Vector3.Distance(cord.transform.position, transform.position)}");
        }
    }
}