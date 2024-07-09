using System;
using Dreamteck.Splines;

namespace Electricity.Couplers.Electrons
{
    public class SplineElectron : Electron
    {
        private SplineFollower _follower;
        
        protected override void Awake()
        {
            base.Awake();
            _follower = GetComponent<SplineFollower>();
        }

        public void Init(SplineComputer spline, float duration, Action onFail, Action onReach, bool isBackward = false)
        {
            base.Init(onFail, spline.GetHashCode());
            
            _follower.followDuration = duration;
            _follower.follow = true;
            _follower.spline = spline;
            
            if (isBackward)
                ResetBackward(onReach);
            else
                ResetForward(onReach);
        }
        
        private void ResetBackward(Action onReach)
        {
            _follower.onBeginningReached = null;
            _follower.onBeginningReached += _ => onReach();
            gameObject.SetActive(true);
            _follower.direction = Spline.Direction.Backward;
            _follower.Restart(1);
        }
        
        private void ResetForward(Action onReach)
        {
            _follower.onEndReached = null;
            _follower.onEndReached += _ => onReach();
            gameObject.SetActive(true);
            _follower.direction = Spline.Direction.Forward;
            _follower.Restart();
        }

        protected override void Stop()
        {
            _follower.follow = false;
        }
    }
}