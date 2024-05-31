using UnityEngine;

public class SegmentController : MonoBehaviour
{
       
    [SerializeField] private Rigidbody2D head;
    [SerializeField] private HingeJoint2D tale;

    [SerializeField] private Rigidbody2D[] allBody;

    public Rigidbody2D[] AllBody => allBody;

    public GameObject Head => head.gameObject;
    public GameObject Tale => tale.gameObject;
    

    [ContextMenu("Reverse")]
    private void Respawn()
    {
        for (int i = 0; i < allBody.Length / 2; i++)
        {
            var tmp = allBody[i];
            allBody[i] = allBody[allBody.Length - i - 1];
            allBody[allBody.Length - i - 1] = tmp;
        }
    }
}