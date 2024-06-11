using UnityEngine;

namespace Snake
{
    public class TaleMobility : SegmentMobility
    {
        [SerializeField] private float passiveMass = 0.001f;
        
        private float _activeMass; 
        private bool _lastMoving;
        
        protected override void Awake()
        {
            base.Awake();
            _activeMass = _body.mass;
            _body.mass = passiveMass;
        }

        protected override void FixedUpdate()
        {
            CalcMass();
            base.FixedUpdate();
        }

        private void CalcMass()
        {
            if (_lastMoving && !_isMoving)
                _body.mass = passiveMass;
            else if (!_lastMoving && _isMoving)
                _body.mass = _activeMass;
            
            _lastMoving = _isMoving;
        }
    }
}