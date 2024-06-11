using UnityEngine;

namespace Electricity
{
    public class BiTimer 
    {
        private float _endTime;
        
        public float _currentTime;

        public bool HasReachedBorder { get; private set; }
        public float LeftTime => IsIncrement ? _endTime - _currentTime : _currentTime;

        public bool IsIncrement { get; private set; }
        
        public void Start(float endTime, bool isIncrement = true)
        {
            IsIncrement = isIncrement;
            _endTime = endTime;
            HasReachedBorder = false;
            _currentTime = isIncrement ? 0 : endTime;
        }
        
        public void Stop()
        {
            HasReachedBorder = true;
            _currentTime = IsIncrement ? _endTime : 0;
        }
        
        public bool Update(float delta)
        {
            if(HasReachedBorder)
                return false;
            
            _currentTime += IsIncrement ? delta : -delta;

            if (IsIncrement && _currentTime < _endTime 
                || !IsIncrement && _currentTime > 0)
                return false;
            
            Stop();
            return true;
        }

        public void SetIncrement(bool isIncrement)
        {
            if(IsIncrement == isIncrement)
                return;

            _currentTime = Mathf.Clamp(_currentTime, 0, _endTime);
            
            IsIncrement = isIncrement;
            HasReachedBorder = false;
        }
    }
}