using System;
using UnityEngine;

namespace Movement
{
    public class SegmentMobility : MonoBehaviour, IMobility
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float magnitude;
        [SerializeField] private float amplitude;
        [SerializeField] private float rotationSpeed;

        public bool CanNotMove { get; set; }
        
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
            if(CanNotMove)
                return;
            
            _isMoving = direction != Vector2.zero;
            if (!_isMoving)
                return;

            _direction.Set(direction.x, direction.y);
        }

        protected virtual void FixedUpdate()
        {
            if(CanNotMove)
                return;
            
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
                _speed += acceleration;
                _speed = Math.Min(_speed, maxSpeed);
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