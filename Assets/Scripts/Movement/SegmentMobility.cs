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
        
        private Rigidbody2D _body;

        private Vector3 _direction;
       
        private bool _isMoving;
        private float _speed;
        
        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }
        
        public void MoveBy(Vector2 direction)
        {
            _isMoving = direction != Vector2.zero;
            if (!_isMoving)
                return;

            _direction.Set(direction.x, direction.y, 0);
        }

        private void FixedUpdate()
        {
            if(CanNotMove)
                return;
            
            ApplyAcceleration();
            
            if(_direction == Vector3.zero)
                return;
            
            if (_isMoving)
                ApplySin();

            var targetRotation = Quaternion.RotateTowards(transform.rotation
                , Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0,0,90) * _direction)
                , rotationSpeed * Time.deltaTime);    
            
            _body.MovePosition(transform.position + Time.deltaTime * _speed * _direction);
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
            _direction += Quaternion.LookRotation(Vector3.forward,_direction) * Vector3.right * (Mathf.Sin(Time.time * amplitude) * magnitude);
        }
    }
}