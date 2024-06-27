namespace GameController
{
    public class Timer
    {
        private float _endTime;
        
        private float _currentTime; 
        private bool _isTimerPlaying;
        
        public void Start(float endTime)
        {
            _endTime = endTime;
            _isTimerPlaying = true;
            _currentTime = 0;
        }
        
        public void Stop()
        {
            _isTimerPlaying = false;
            _currentTime = 0;
        }
        
        public bool Update(float delta)
        {
            if(!_isTimerPlaying)
                return false;
            
            _currentTime += delta;

            if (_currentTime < _endTime)
                return false;
            
            Stop();
            return true;
        }
    }
}