using System;
using UnityEngine;

namespace Snake
{
    public class SegmentMobility : MonoBehaviour, IMobility
    {
        public float maxSpeed; 
        
        [SerializeField] private float acceleration;
        [SerializeField] private float magnitude;
        [SerializeField] private float amplitude;
        [SerializeField] private float rotationSpeed;

        private bool _canNotMove;
        public bool CanNotMove
        {
            get => _canNotMove;
            set
            {
                _canNotMove = value;
                _isMoving = false;
                _direction = Vector2.zero;
            }
        }

        protected Rigidbody2D _body;

        private Vector2 _direction;
       
        protected bool _isMoving;
        
        private float _speed;
       
        
        protected virtual void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }
        
        public void MoveBy(Vector2 direction)
        {
            _isMoving = direction != Vector2.zero || CanNotMove;
            if (!_isMoving)
                return;

            _direction.Set(direction.x, direction.y);
        }

        protected virtual void FixedUpdate()
        {
            ApplyAcceleration();
            
            if (_isMoving)
                ApplySin();

            var rotation = transform.rotation;
            var targetRotation = _isMoving ? Quaternion.RotateTowards(rotation
                , Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0,0,90) * _direction)
                , rotationSpeed * Time.deltaTime) : rotation;    
            
            _body.MovePosition(_body.position + Time.deltaTime * _speed * _direction);
            _body.MoveRotation(targetRotation);
        }

        private void ApplyAcceleration()
        {
            if (_isMoving)
            {
                _speed += maxSpeed > _speed ? acceleration : -acceleration;
                return;
            }
            
            _speed -= acceleration * 4;
            _speed = Math.Max(_speed, 0);
        }

        private void ApplySin()
        {
            _direction += (Vector2) transform.up * (Mathf.Sin(Time.time * amplitude) * magnitude);
        }
    }
}