using System.Linq;
using UnityEngine;

namespace Utils
{
    public class ConnectToChild : MonoBehaviour
    {

        [ContextMenu("aa")]
        private void Connect()
        {
            GetComponentsInChildren<HingeJoint2D>().First(go => go.gameObject != gameObject).connectedBody = GetComponent<Rigidbody2D>();
        }
        
    }
}