﻿using Electricity.Couplers;
using UnityEngine;

namespace Snake
{
    public class SnakeAdapter : MonoBehaviour, IMobility
    {
        [SerializeField] private float activeDrag;
        [SerializeField] private float passiveDrag;
        
        public bool CanNotMove { get; set; }
        
        private IMobility _headMobility;
        private IMobility _taleMobility;

        private FindingCoupler _findingCoupler;

        private SegmentController _segmentController;
        
        private bool _isMoving;
        
        private void Start()
        {
            _segmentController = GetComponent<SegmentController>();
            
            _taleMobility = _segmentController.Tale.gameObject.GetComponent<IMobility>();
            _headMobility = _segmentController.Head.gameObject.GetComponent<IMobility>();

            _findingCoupler = GetComponent<FindingCoupler>();
        }

       
        public void MoveBy(Vector2 direction)
        {
            CalcDrag(direction);
            
            _headMobility.CanNotMove =  CanNotMove || _findingCoupler.IsConnectedA;
            _taleMobility.CanNotMove = CanNotMove || _findingCoupler.IsConnectedB || !_headMobility.CanNotMove;
            
            if (!_headMobility.CanNotMove)
                _headMobility.MoveBy(direction);
            else if (!_taleMobility.CanNotMove)
                _taleMobility.MoveBy(direction);
        }

        private void CalcDrag(Vector2 direction)
        {
            var isCurrentMoving = direction != Vector2.zero;

            if (_isMoving && !isCurrentMoving)
                SetPassiveDrag();
            else if (!_isMoving && isCurrentMoving)
                SetActiveDrag();

            _isMoving = isCurrentMoving;
        }


        private void SetPassiveDrag()
        {
            foreach (var segment in _segmentController.AllBody)
                segment.drag = passiveDrag;
        }
        
        private void SetActiveDrag()
        {
            foreach (var segment in _segmentController.AllBody)
                segment.drag = activeDrag;
        }
    }
}