using UnityEngine;

public class SegmentController : MonoBehaviour
{
       
    [SerializeField] private Rigidbody2D head;
    [SerializeField] private HingeJoint2D tale;
    [Space]
    [SerializeField] private int segmentCount;
    [SerializeField] private HingeJoint2D bodyPrefab;

    public Rigidbody2D[] AllBody { get; private set; }
        
    public GameObject Head => head.gameObject;
    public GameObject Tale => tale.gameObject;
        
    private readonly Vector3 _offset = new(-0.05f, 0, 0);

      

    [ContextMenu("Respawn")]
    private void Respawn()
    {
        for (var i = 0; i < AllBody.Length-1; i++)
            Destroy(AllBody[i].gameObject);
            
        head.transform.rotation = Quaternion.Euler(0,0,0);
            
        AllBody = new Rigidbody2D[segmentCount];
        Spawn();
    }

    private void Awake()
    {
        AllBody = new Rigidbody2D[segmentCount];
        Spawn();
    }

    private void Spawn()
    {
        var connected = CreateNext(head, 0);
        AllBody[0] = connected;
           
        for (var i = 1; i < segmentCount; i++)
        {
            connected = CreateNext(connected, i);
            AllBody[i] = connected;
        }
    }

    private Rigidbody2D CreateNext(Rigidbody2D lastSegment, int id)
    {
        HingeJoint2D next;
            
        var scale = 1 - (id + 2) / (segmentCount / 0.8f);
            
        if (IsTale(id))
        {
            next = tale;
            next.transform.position = lastSegment.transform.position + _offset;
        }
        else
        {
            var trans = transform;
            next = Instantiate(bodyPrefab, lastSegment.transform.position + _offset, trans.rotation, trans);
        }

        next.connectedBody = lastSegment;
            
        next.transform.localScale = new Vector3(scale, scale, scale);

        next.GetComponentInChildren<SpriteRenderer>().sortingOrder = -id;

        return next.GetComponent<Rigidbody2D>();
    }

    private bool IsTale(int id)
    {
        return id == segmentCount - 1;
    }
}