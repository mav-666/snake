using DG.Tweening;
using Movement;
using UnityEngine;

namespace Electricity.Couplers
{
    [RequireComponent(typeof(SegmentController))]
    public class SnakeCoupler : PointCoupler
    {
        [SerializeField] private float animationDuration;

        private IMobility _head;
        private Rigidbody2D _headRigid;
        
        private IMobility _tale;
        private Rigidbody2D _taleRigid;

        private void Start()
        {
            var segments = GetComponent<SegmentController>();
            
            _head = segments.Head.GetComponent<IMobility>();
            _headRigid = segments.Head.GetComponent<Rigidbody2D>();

            _tale = segments.Tale.GetComponent<IMobility>();
            _taleRigid = segments.Tale.GetComponent<Rigidbody2D>();

            InitPointArray(segments);
        }

        private void InitPointArray(SegmentController segments)
        {
            var points = new Transform[segments.AllBody.Length + 2];

            points[0] = segments.Head.transform;
            points[^1] = segments.Tale.transform;
            
            for (var i = 0; i < segments.AllBody.Length; i++)
                points[i+1] = segments.AllBody[i].transform;
            
            Init(points);
        }
        
        public override void FindA()
        {
            base.FindA();
            
            if(IsConnectedA)
                MoveAnimationFor(_head,_headRigid, A);
        }

        public override void FindB()
        {
            base.FindB();
            
            if(IsConnectedB)
                MoveAnimationFor(_tale,_taleRigid, B);
        }

        private void MoveAnimationFor(IMobility segment, Rigidbody2D rigid, Electric electric)
        {
            segment.CanNotMove = true;
            Freeze(rigid);
            rigid.DOMove(electric.transform.position, animationDuration)
                .OnComplete(() => Freeze(rigid)).SetUpdate(UpdateType.Fixed);
        }

        private void Freeze(Rigidbody2D rigid)
        {
            rigid.bodyType = RigidbodyType2D.Static;
        }

        public override void BreakA()
        {
            base.BreakA();
            Unfreeze(_head, _headRigid);
        }

        public override void BreakB()
        {
            base.BreakB();
            Unfreeze(_tale, _taleRigid);
        }

        private void Unfreeze(IMobility segment, Rigidbody2D rigid)
        {
            segment.CanNotMove = false;
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}